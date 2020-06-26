using System;
using System.Collections.Generic;
using System.Xml.Serialization;

using Framework.Core;
using Newtonsoft.Json;

namespace Framework.Entity
{
    /// <summary>
    /// It provides a base class called Business Entities Structure (Base Model) used to map automatticaly the properties without using reflection from the database/datasource
    /// </summary>
    /// <example>
    ///     <code>
    ///     [Serializable]
    ///     public class UsuarioBES : BussinessEntityStructure
    ///     {
    ///         #region| Properties |
    ///         
    ///         public int ID { get; set; }
    ///         public string Nome { get; set; }
    ///
    ///         #endregion
    ///         
    ///         public UsuarioBES()
    ///         {
    ///             Map("CD_ID", "ID");
    ///             Map("Nome");
    ///         }
    ///     }
    ///     </code>
    /// </example>
    [Serializable]
    public abstract class BusinessEntityStructure : IDisposable
    {
        #region| Fields |

        [NonSerialized]
        private Dictionary<string, string> oProperties = null;

        #endregion

        #region| Properties | 

        /// <summary>
        /// Stores the class properties mapping relationship
        /// </summary>
        [XmlIgnore, JsonIgnore]
        public Dictionary<string, string> MappedProperties
        {
            get
            {
                return this.oProperties;
            }
            set
            {
                this.oProperties = value;
            }
        }

        #endregion

        #region| Constructor |

        /// <summary>
        /// Bussiness Entity Structure Construtor
        /// </summary>
        protected BusinessEntityStructure()
        {
            this.MappedProperties = new Dictionary<string, string>();
        }

        #endregion

        #region| Destructor | 

        /// <summary>
        /// Default destructor
        /// </summary>
        ~BusinessEntityStructure()
        {
            this.Dispose();
        }

        #endregion

        #region| Methods |

        /// <summary>
        /// Maps the class property to be filled with the datasource column
        /// </summary>
        /// <param name="ColumnName">Column Name</param>
        /// <param name="PropertyName">Property Name</param>
        /// <example>
        /// <code>
        ///     public UsuarioBES()
        ///     {
        ///         Map("CD_ID", "ID");
        ///         Map("DS_NAME","Nome");
        ///     }
        /// </code>
        /// </example>
        protected void Map(string ColumnName, string PropertyName)
        {
            if (ColumnName.IsNotNull() && PropertyName.IsNotNull())
            {
                this.AddMapping(ColumnName, PropertyName);
            }
        }

        /// <summary>
        /// Maps the class property to be filled with the datasource column
        /// </summary>
        /// <remarks>
        /// The property name must be the same to the datasource column name
        /// </remarks>
        /// <param name="PropertyName">Property Name</param>
        /// <example>
        /// <code>
        ///     public UsuarioBES()
        ///     {
        ///         Map("ID");
        ///         Map("Nome");
        ///     }
        /// </code>
        /// </example>
        protected void Map(string PropertyName)
        {
            if (PropertyName.IsNotNull())
            {
                this.AddMapping(PropertyName, PropertyName);
            }
        }

        /// <summary>
        /// Maps the class property to be filled with the datasource column
        /// </summary>
        /// <param name="PropertyName">Property Name</param>
        /// <param name="ColumnName">Column Name</param>
        private void AddMapping(string PropertyName, string ColumnName)
        {
            if (this.MappedProperties.ContainsKey(PropertyName)==false)
            {
                this.MappedProperties.Add(PropertyName, ColumnName);
            }
        }

        #endregion

        #region| IDisposable Members |

        /// <summary>
        /// Release allocated resource
        /// </summary>
        public void Dispose()
        {
            this.MappedProperties = null;
            this.oProperties = null;
        }

        #endregion
    }
}
