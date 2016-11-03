using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using TwinTechs.Controls;

namespace XtrFastListViewSample.Droid.Renderers
{
    public class FastCellCache : IFastCellCache
    {
        static FastCellCache _instance;

        FastCellCache()
        {
            _cachedDataByView = new Dictionary<Android.Views.View, CachedData>();
        }

        public static FastCellCache Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FastCellCache();
                }
                return _instance;
            }
        }

        Dictionary<Android.Views.View, CachedData> _cachedDataByView;

        public CachedData GetCellCache(ViewGroup parent)
        {
            if (!_cachedDataByView.ContainsKey(parent))
            {
                _cachedDataByView[parent] = new CachedData();
            }
            return _cachedDataByView[parent];
        }

        #region IFastCellCache impl

        //TODO maintain mapping of cell to original?

        public void FlushAllCaches()
        {
            foreach (var cachedData in _cachedDataByView.Values)
            {
                cachedData.Reset();
            }

            _cachedDataByView = new Dictionary<Android.Views.View, CachedData>();
        }

        #endregion

        public class CachedData
        {
            internal CachedData()
            {
                Reset();
            }

            /// <summary>
            /// Reset this instance. 
            /// </summary>
            internal void Reset()
            {
                CellItemsByCoreCells = new Dictionary<Android.Views.View, FastCell>();
                OriginalBindingContextsForReusedItems = new Dictionary<FastCell, object>();
            }

            Dictionary<Android.Views.View, FastCell> CellItemsByCoreCells { get; set; }

            Dictionary<FastCell, object> OriginalBindingContextsForReusedItems { get; set; }

            public void RecycleCell(Android.Views.View view, FastCell newCell)
            {
                if (CellItemsByCoreCells.ContainsKey(view))
                {
                    var reusedItem = CellItemsByCoreCells[view];
                    if (OriginalBindingContextsForReusedItems.ContainsKey(newCell))
                    {
                        reusedItem.BindingContext = OriginalBindingContextsForReusedItems[newCell];
                    }
                    else
                    {
                        reusedItem.BindingContext = newCell.BindingContext;
                    }
                }
            }

            public bool IsCached(Android.Views.View view)
            {
                return CellItemsByCoreCells.ContainsKey(view);
            }

            public void CacheCell(FastCell cell, Android.Views.View view)
            {
                CellItemsByCoreCells[view] = cell;
                OriginalBindingContextsForReusedItems[cell] = cell.BindingContext;
            }

            public object GetBindingContextForReusedCell(FastCell cell)
            {
                if (OriginalBindingContextsForReusedItems.ContainsKey(cell))
                {
                    return OriginalBindingContextsForReusedItems[cell];
                }
                else
                {
                    return null;
                }
            }

            void CacheBindingContextForReusedCell(FastCell cell)
            {
                OriginalBindingContextsForReusedItems[cell] = cell.BindingContext;
            }




        }
    }
}