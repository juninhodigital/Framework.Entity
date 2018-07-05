using System.Collections.Generic;
using System.Data;

using Framework.Core;

namespace Framework.Entity.Extensions
{
    /// <summary>
    /// Providers Extension Methods that are a special kind of static method, 
    /// but they are called as if they were instance methods on the extended type. 
    /// </summary>
    public static partial class Extensions
    {
        #region| Methods |

        /// <summary>
        /// Converts a generic list into a DataTable
        /// </summary>
        /// <typeparam name="T">Type of objects int list</typeparam>
        /// <param name="List">List to be converted</param>
        /// <returns>Converted DataTable</returns>
        public static DataTable ToDataTable<T>(this List<T> @List) where T : BusinessEntityStructure
        {
            var oDataTable = new DataTable();

            if (@List.IsNotNull())
            {
                var oEntity = @List[0];

                if (oEntity.IsNotNull() && oEntity.MappedProperties.IsNotNull())
                {
                    for (int i = 0; i < oEntity.MappedProperties.Count; i++)
                    {
                        var item = oEntity.MappedProperties[i];

                        oDataTable.Columns.Add(item.PropertyName);
                    }

                    if (oDataTable.Columns.Count > 0)
                    {
                        for (int i = 0; i < @List.Count; i++)
                        {
                            T item = @List[i];

                            DataRow oRow = oDataTable.NewRow();

                            for (int y = 0; i < item.MappedProperties.Count; y++)
                            {
                                var prop = item.MappedProperties[y];

                                var oPropertyInfo = item.GetType().GetProperty(prop.PropertyName);

                                if (oPropertyInfo.CanRead)
                                {
                                    oRow[prop.PropertyName] = oPropertyInfo.GetValue(item, null);
                                }
                            }

                            oDataTable.Rows.Add(oRow);
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            else
            {
                return null;
            }

            return oDataTable;
        } 
        
        #endregion
    }
}
