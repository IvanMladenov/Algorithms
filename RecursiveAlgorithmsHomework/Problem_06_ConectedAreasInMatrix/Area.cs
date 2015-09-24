namespace Problem_06_ConectedAreasInMatrix
{
    using System;

    public class Area:IComparable<Area>
    {
        public Area(int[] position)
        {
            this.Position = position;
        }

        public int[] Position { get; set; }

        public int Size { get; set; }

        public override string ToString()
        {
            return String.Format("Area #1 at ({0}, {1}), size: {2}", this.Position[0], this.Position[1], this.Size);
        }

        public int CompareTo(Area other)
        {
            int compareSize = -1*this.Size.CompareTo(other.Size);

            if (compareSize == 0)
            {
                int compareRows = this.Position[0].CompareTo(other.Position[0]);

                if (compareRows == 0)
                {
                    return this.Position[1].CompareTo(other.Position[1]);
                }
                else
                {
                    return compareRows;
                }
            }
            else
            {
                return compareSize;
            }
        }
    }
}
