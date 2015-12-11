using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PongGame {
    public class CollisionDetector {
        /// <summary>
        /// Calculates if rectangles describing two sprites
        /// are overlapping on screen.
        /// </summary>
        /// <param name="s1">First sprite</param>
        /// <param name="s2">Second sprite</param>
        /// <returns>Returns true if overlapping</returns>
        public static bool Overlaps(Ball s1, Sprite s2) {
            float testX = s1.Position.X;
            float testY = s1.Position.Y;

            if (testX < s2.Position.X)
                testX = s2.Position.X;
            if (testX >= (s2.Position.X + s2.Size.Width / 1.5f))
                testX = (s2.Position.X + s2.Size.Width / 1.5f);
            if (testY < s2.Position.Y)
                testY = s2.Position.Y;
            if (testY >= (s2.Position.Y - s2.Size.Height / 2))
                testY = (s2.Position.Y - s2.Size.Height / 2);

            return ((s1.Position.X - testX) * (s1.Position.X - testX) + (s1.Position.Y - testY) * (s1.Position.Y - testY)) <= (s1.Size.Width) * (s1.Size.Height);
        }
    }
}