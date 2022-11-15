using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEditor;
using UnityEngine;

namespace Ai.manager
{
    public static class Extensions
    {
        public class WeightEnum<T> where T : struct
        {
            private IReadOnlyDictionary<T, int> _keys;
            private float[] _values;

            public float this[T key]
            {
                get { return _values[_keys[key]]; }
                set { _values[_keys[key]] = value; }
            }

            public int Count => _keys.Count;

            public IEnumerable<T> Keys => _keys.Keys;

            public WeightEnum()
            {
                var array = Enum.GetValues(typeof(T));

                var keys = new Dictionary<T, int>(array.Length);
                _values = new float[array.Length];

                int i = 0;
                foreach (var en in array)
                {
                    keys.Add((T)en, i);
                    i++;
                }

                _keys = keys;
            }

            public WeightEnum(IReadOnlyDictionary<T, float> weights)
            {
                var keys = new Dictionary<T, int>(weights.Count);
                var _values = new float[weights.Count];

                int i = 0;
                foreach (var pair in weights)
                {
                    keys.Add(pair.Key, i);
                    _values[i] = pair.Value;
                    i++;
                }
            }

            public IEnumerator<KeyandWeightPair<T, float>> GetEnumerator()
            {
                return new GroupEnumerator(_keys, _values);
            }

            public struct KeyandWeightPair<T1, T2> where T1 : struct where T2 : struct
            {
                public T1 Key;
                public T2 Weight;

                public KeyandWeightPair(T1 key, T2 weight)
                {
                    Key = key; Weight = weight;
                }
            }

            private class GroupEnumerator : IEnumerator<KeyandWeightPair<T, float>>
            {
                private List<KeyandWeightPair<T, float>> _list;
                private int _current = -1;

                public GroupEnumerator(IReadOnlyDictionary<T, int> keys, float[] _values)
                {
                    _list = new List<KeyandWeightPair<T, float>>(keys.Count);

                    foreach (var el in keys)
                    {
                        _list.Add(new KeyandWeightPair<T, float>(el.Key, _values[el.Value]));
                    }
                }

                public KeyandWeightPair<T, float> Current => Current;

                object IEnumerator.Current => Current;

                public void Dispose() { }

                public bool MoveNext()
                {
                    if (_current < _list.Count - 1)
                    {
                        _current++;
                        return true;
                    }

                    return false;
                }

                public void Reset()
                {
                    _current = 0;
                }
            }
        }
    }
}
