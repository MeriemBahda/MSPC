﻿using Genometric.IGenomics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Genometric.MSPC.Core.IntervalTree
{
    internal class Node<Peak, Metadata>
        where Peak : IInterval<int, Metadata>, IComparable<Peak>, new()
        where Metadata : IChIPSeqPeak, IComparable<Metadata>, new()
    {
        private SortedDictionary<Peak, List<Peak>> _intervals;
        private int _center;
        private Node<Peak, Metadata> _leftNode;
        private Node<Peak, Metadata> _rightNode;

        public Node()
        {
            _intervals = new SortedDictionary<Peak, List<Peak>>();
            _center = 0;
            _leftNode = null;
            _rightNode = null;
        }

        public Node(List<Peak> intervalsList)
        {
            _intervals = new SortedDictionary<Peak, List<Peak>>();
            var endpoints = new SortedSet<int>();
            foreach (var interval in intervalsList)
            {
                endpoints.Add(interval.left);
                endpoints.Add(interval.right);
            }

            int? median = GetMedian(endpoints);
            _center = median.GetValueOrDefault();

            var left = new List<Peak>();
            var right = new List<Peak>();

            foreach (Peak interval in intervalsList)
            {
                if (interval.right.CompareTo(_center) < 0)
                    left.Add(interval);
                else if (interval.left.CompareTo(_center) > 0)
                    right.Add(interval);
                else
                {
                    List<Peak> posting;
                    if (!_intervals.TryGetValue(interval, out posting))
                    {
                        posting = new List<Peak>();
                        _intervals.Add(interval, posting);
                    }
                    posting.Add(interval);
                }
            }

            if (left.Count > 0)
                _leftNode = new Node<Peak, Metadata>(left);
            if (right.Count > 0)
                _rightNode = new Node<Peak, Metadata>(right);
        }

        private int? GetMedian(SortedSet<int> set)
        {
            int i = 0;
            int middle = set.Count / 2;
            foreach (var point in set)
            {
                if (i == middle)
                    return point;
                i++;
            }
            return null;
        }

        private List<Peak> GetIntervalsOfKeys(List<Peak> intervalKeys)
        {
            var allIntervals =
              from k in intervalKeys
              select _intervals[k];

            return allIntervals.SelectMany(x => x).ToList();
        }

        public IEnumerable<IList<Peak>> Intersections
        {
            get
            {
                if (_intervals.Count == 0) yield break;
                else if (_intervals.Count == 1)
                {
                    if (_intervals.First().Value.Count > 1)
                    {
                        yield return _intervals.First().Value;
                    }
                }
                else
                {
                    var keys = _intervals.Keys.ToArray();

                    int lastIntervalIndex = 0;
                    var intersectionsKeys = new List<Peak>();
                    for (int index = 1; index < _intervals.Count; index++)
                    {
                        var intervalKey = keys[index];
                        if (IntervalOperations<Peak, Metadata>.Intersects(intervalKey, keys[lastIntervalIndex]))
                        {
                            if (intersectionsKeys.Count == 0)
                            {
                                intersectionsKeys.Add(keys[lastIntervalIndex]);
                            }
                            intersectionsKeys.Add(intervalKey);
                        }
                        else
                        {
                            if (intersectionsKeys.Count > 0)
                            {
                                yield return GetIntervalsOfKeys(intersectionsKeys);
                                intersectionsKeys = new List<Peak>();
                                index--;
                            }
                            else
                            {
                                if (_intervals[intervalKey].Count > 1)
                                {
                                    yield return _intervals[intervalKey];
                                }
                            }

                            lastIntervalIndex = index;
                        }
                    }

                    if (intersectionsKeys.Count > 0) yield return GetIntervalsOfKeys(intersectionsKeys);
                }
            }
        }

        public List<Peak> Stab(int time, ContainConstrains constraint)
        {
            List<Peak> result = new List<Peak>();

            foreach (var entry in _intervals)
            {
                if (IntervalOperations<Peak, Metadata>.Contains(entry.Key, time, constraint))
                    foreach (var interval in entry.Value)
                        result.Add(interval);
                else if (entry.Key.left.CompareTo(time) > 0)
                    break;
            }

            if (time.CompareTo(_center) < 0 && _leftNode != null)
                result.AddRange(_leftNode.Stab(time, constraint));
            else if (time.CompareTo(_center) > 0 && _rightNode != null)
                result.AddRange(_rightNode.Stab(time, constraint));
            return result;
        }

        public List<Peak> Query(Peak target)
        {
            List<Peak> result = new List<Peak>();

            foreach (var entry in _intervals)
            {
                if (IntervalOperations<Peak, Metadata>.Intersects(entry.Key, target))
                    foreach (Peak interval in entry.Value)
                        result.Add(interval);
                else if (entry.Key.left.CompareTo(target.right) > 0)
                    break;
            }

            if (target.left.CompareTo(_center) < 0 && _leftNode != null)
                result.AddRange(_leftNode.Query(target));
            if (target.right.CompareTo(_center) > 0 && _rightNode != null)
                result.AddRange(_rightNode.Query(target));
            return result;
        }


        public int Center
        {
            get { return _center; }
            set { _center = value; }
        }

        public Node<Peak, Metadata> Left
        {
            get { return _leftNode; }
            set { _leftNode = value; }
        }

        public Node<Peak, Metadata> Right
        {
            get { return _rightNode; }
            set { _rightNode = value; }
        }
    }
}
