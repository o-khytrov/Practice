using System;
using System.IO;
using System.Linq;

namespace RadiatorSprings
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            checked
            {
                var value = Environment.GetEnvironmentVariable("Console_Txt", EnvironmentVariableTarget.User);
                if (value == "True")
                    Console.SetIn(new StreamReader("Console.txt"));

                var A = Console.ReadLine().Trim().Split(' ').Select(Double.Parse).ToArray();
                var acceleration = A[0]; //acceleration
                var maxSpeed = A[1]; // maximum speed

                A = Console.ReadLine().Trim().Split(' ').Select(Double.Parse).ToArray();
                var lenghtOfRoad = A[0]; // length of the road
                var speedSign = A[1];// place of speed sign
                var speedLimit = A[2];// place of speed sign
                double totalTime = 0;
                if (speedLimit <= maxSpeed)
                {
                    var accelerationDistance = acceleration / Math.Min(speedLimit, maxSpeed);
                    var rest = lenghtOfRoad - accelerationDistance;
                    totalTime = acceleration + rest * maxSpeed;
                }
                else
                {
                    var accelerationDistance = Math.Min(speedLimit, maxSpeed) / acceleration;
                    var accelerationTime = accelerationDistance / (Math.Min(speedLimit, maxSpeed) / 2);
                    accelerationTime = accelerationTime * accelerationTime;
                    var dif = speedLimit - maxSpeed;

                    var MaxSpeedDistance = speedSign - accelerationDistance;

                    var maxSpeedTime = MaxSpeedDistance / Math.Min(speedLimit, maxSpeed); ;
                    var distanceWithoutLimit = lenghtOfRoad - speedSign;
                    var timeWithoutLimit = (distanceWithoutLimit) / Math.Max(speedLimit, maxSpeed);
                    totalTime = accelerationTime + maxSpeedTime + timeWithoutLimit;
                    var isCorrect = MaxSpeedDistance + accelerationDistance + distanceWithoutLimit == lenghtOfRoad;
                }
                Console.WriteLine(totalTime.ToString("#.000000000", System.Globalization.CultureInfo.InvariantCulture));
            }

            Console.ReadKey();
        }
    }
}