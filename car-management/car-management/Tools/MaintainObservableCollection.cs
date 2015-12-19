using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace car_management.Tools
{
    public static class MaintainObservableCollection
    {
        /// <summary>
        /// maintains an ObservableCollection
        /// </summary>
        public static ObservableCollection<T> Maintain<T>(this ObservableCollection<T> observableCollection, IEnumerable<T> enumerable)
        {
            ObservableCollection<T> observedEnum = enumerable.ToObservableCollection();

            bool maintain = false;

            maintain = observableCollection.Count != observedEnum.Count;    // is maintaining necessary       
            if (!maintain)
            {
                for (int i = 0; i < observedEnum.Count; i++)
                {
                    if (!observedEnum[i].Equals(observableCollection[i]))
                    {
                        maintain = true;
                        break;
                    }
                }
            }

            if(!maintain)
            return observableCollection;                                // nothing to do here!


            // start maintaining
            for (int i = 0; i < observedEnum.Count; i++)                // add item Attention FORWARD!
            {
                if (!observableCollection.Contains(observedEnum[i]))
                {
                    observableCollection.Insert(i, observedEnum[i]);
                }
            }

            for (int i = observableCollection.Count - 1; i >= 0; i--)        // remove item Attention BACKWARDS!
            {
                if (!observedEnum.Contains(observableCollection[i]))
                {
                    observableCollection.RemoveAt(i);
                }
            }

            if (observableCollection.Count!=observedEnum.Count)
                throw new Exception("Collection contains same object at least twice!");

            for (int i = 0; i < observedEnum.Count; i++)                                // sort       
            {
                if (!observedEnum[i].Equals(observableCollection[i]))
                {
                    for (int ii = i; ii < observableCollection.Count; ii++)
                    {
                        if (observedEnum[i].Equals(observableCollection[ii]))
                        {
                            observableCollection.Move(ii, i);
                        }
                    }
                }
            }

            for (int i = 0; i < observedEnum.Count; i++)                                //check the results                           
            {
                if (!observedEnum[i].Equals(observableCollection[i]))
                {
                   throw new Exception("maintaining observable collection failed!");
                }
            }
            return observableCollection;
        }


        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> source)
        {
            var result = new ObservableCollection<T>();
            foreach (var item in source)
                result.Add(item);
            return result;
        }
    }
}