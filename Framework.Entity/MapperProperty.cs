using System;

namespace Framework.Entity
{
    /// <summary>
    /// Class that has the property name mapped to its column name from the datasource
    /// </summary>
    [Serializable]
    public sealed class MapperProperty
    {
        #region| Properties |
        
        /// <summary>
        /// DataSource Column Name
        /// </summary>
        public string ColumnName { get; set; }

        /// <summary>
        /// Class Property Name
        /// </summary>
        public string PropertyName { get; set; }

        #endregion

        #region| Constructor |

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="ColumnName">DataSource Column Name</param>
        /// <param name="PropertyName">Class Property Name</param>
        public MapperProperty(string ColumnName, string PropertyName)
        {
            this.ColumnName     = ColumnName;
            this.PropertyName   = PropertyName;
        }
        
        #endregion

    }
}
