using System;
using System.Collections.Generic;
using NextAfter.Net;

namespace IntervalClass
{
    public readonly partial struct Interval
    {
        public Interval Intersect(Interval otherInterval)
        {
            if (IsEmpty || otherInterval.IsEmpty)
                return Empty;

            var leftIntersectionBound = Math.Max(LowerBound, otherInterval.LowerBound);
            var rightIntersectionBound = Math.Min(UpperBound, otherInterval.UpperBound);

            if (leftIntersectionBound > rightIntersectionBound)
                return Empty;

            return new Interval(leftIntersectionBound, rightIntersectionBound);
        }

        public bool IsPoint()
        {
            if (IsEmpty)
                return false;
            
            return LowerBound == UpperBound;
        }
        
        public bool ContainsAnyInteger()
        {
            if (IsEmpty)
                return false;

            return Math.Floor(UpperBound) >= Math.Ceiling(LowerBound);
        }

        public Interval UnityWith(Interval otherInterval)
        {
            if (IsEmpty)
                return otherInterval;

            if (otherInterval.IsEmpty)
                return this;

            var leftBound = Math.Min(LowerBound, otherInterval.LowerBound);
            var rightBound = Math.Max(UpperBound, otherInterval.UpperBound);

            return new Interval(leftBound, rightBound);
        }

        public bool Contains(double number)
        {
            if (IsEmpty)
                return false;

            return LowerBound <= number && UpperBound >= number;
        }

        public bool Contains(Interval interval)
        {
            if (IsEmpty)
                return false;

            if (interval.IsEmpty)
                return false;

            return Contains(interval.LowerBound) && Contains(interval.UpperBound);
        }

        public Interval[] Except(Interval otherInterval)
        {
            // thisInterval [--]
            // otherInterval (--)
            // (--)--[--]
            if (!IsIntersects(otherInterval))
            {
                return new Interval[] { this };
            }

            if (otherInterval.LowerBound <= LowerBound)
            {
                // (--[
                if (otherInterval.UpperBound >= UpperBound)
                {
                    // (--[---]--)
                    return Array.Empty<Interval>();
                }
                else
                {
                    // (--[--)--]
                    return new Interval[] { new Interval(otherInterval.UpperBound, this.UpperBound) };
                }
            }
            else
            {
                // [--(
                if (otherInterval.UpperBound > UpperBound)
                {
                    // [--(--]--)
                    return new Interval[] { new Interval(this.LowerBound, otherInterval.LowerBound) };
                }
                else
                {
                    // [--(--)--]
                    return new Interval[]
                    {
                        new Interval(this.LowerBound, otherInterval.LowerBound),
                        new Interval(otherInterval.UpperBound, this.UpperBound)
                    };
                }
            }
        }

        public Interval Width()
        {
            if (IsEmpty)
                return Empty;

            if (IsPoint())
                return (Interval)0.0;

            return (Interval)UpperBound - (Interval)LowerBound;
        }

        public Interval Radius()
        {
            if (IsEmpty)
                return Empty;

            var width = Width();
            var radius = width / new Interval(2.0);
            
            return radius;
        }

        public Interval Middle()
        {
            if (IsEmpty)
                return Empty;

            var middle = ((Interval)LowerBound + (Interval)UpperBound) / (Interval)2.0;
            
            // intersects because middle must be into interval
            return middle.Intersect(this);
        }

        public Interval[] Dichotomy()
        {
            if (IsEmpty)
                return Array.Empty<Interval>();

            var middle = Middle();
            var middlePoint = middle.LowerBound;
            var leftPart = new Interval(LowerBound, middlePoint);
            var rightPart = new Interval(middlePoint, UpperBound);

            var result = new List<Interval>();
            
            if (!leftPart.IsPoint())
                result.Add(leftPart);
            
            if (!rightPart.IsPoint())
                result.Add(rightPart);

            return result.Count > 0
                ? result.ToArray()
                : new Interval[] { leftPart };
        }

        public bool IsIntersects(Interval otherInterval)
        {
            return !Intersect(otherInterval).IsEmpty;
        }

        public double Magnitude()
        {
            if (IsEmpty)
                return double.NaN;

            return Math.Max(Math.Abs(LowerBound), Math.Abs(UpperBound));
        }

        public double Mignitude()
        {
            if (IsEmpty)
                return double.NaN;

            if (Contains(0.0))
                return 0.0;

            return Math.Min(Math.Abs(LowerBound), Math.Abs(UpperBound));
        }
    }
}