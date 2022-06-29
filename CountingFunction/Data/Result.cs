using System.Collections.ObjectModel;

namespace CountingFunction
{
    public class Result
    {
        #region Properties
        private double _x { get; set; }
        /// <summary>
        /// Данное поле хранит информацию о значении x.
        /// </summary>
        public double X
        {
            get { return _x; }
            set
            {
                _x = value;
            }
        }

        private double _y { get; set; }
        /// <summary>
        /// Данное поле хранит информацию о значении y.
        /// </summary>
        public double Y
        {
            get { return _y; }
            set
            {
                _y = value;
            }
        }
        /// <summary>
        /// Данное поле хранит информацию о значении f(x, y).
        /// </summary>
        private double _fxy { get; set; }
        public double Fxy
        {
            get { return _fxy; }
            set
            {
                _fxy = value;
            }
        }

        #endregion
    }
}
