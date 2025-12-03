using Day1;

var rotations = RotationReader.Read("Input.txt");

var zeroRotations = rotations.CountZeroRotations();
Console.WriteLine(zeroRotations);

var zeroClicks = rotations.CountZeroClicks(50);
Console.WriteLine(zeroClicks);
