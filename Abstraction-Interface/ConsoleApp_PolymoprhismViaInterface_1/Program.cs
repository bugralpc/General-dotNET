namespace ConsoleApp_PolymoprhismViaInterface_1
{
    // URLs
    // https://codeeasy.io/lesson/polymorphism
    internal class Program
    {
        // It sounds like polymoprhism is the ability to drive different cars that all use the same controls

        // Polymoprhism is about Inheritance
        // Polymoprhism means an object can take different types
        static void Main(string[] args)
        {
            // Polymoprhism via Interface
            ElectricCarFromICar electricCarFromICar = new ElectricCarFromICar();
            PetrolCarFromICar petrolCarFromICar = new PetrolCarFromICar();

            AccelerateCar(electricCarFromICar);
            AccelerateCar(petrolCarFromICar);

            Console.WriteLine("----------------------------------");

            // Polymorphsim via Base Class
            ElectricCarFromCar electricCarFromCar = new ElectricCarFromCar();
            PetrolCarFromCar petrolCarFromCar = new PetrolCarFromCar();
            Car car = new Car();

            AccelerateCar(electricCarFromCar);
            AccelerateCar(petrolCarFromCar);
            AccelerateCar(car);

            Console.WriteLine("----------------------------------");

            // You can assign an object of a child class to a variable of the parent class
            // right side of "=" is assiginin an object
            // left side of "=" is variable of the class
            Car carFromCar1 = new Car();
            Car carFromCar2 = new ElectricCarFromCar();
            Car carFromCar3 = new PetrolCarFromCar();

            carFromCar1.Accelerate();
            carFromCar2.Accelerate();
            carFromCar3.Accelerate(); // C# knows that it shoudl call Accelerate from PetrolCarFromCar

            // we can do this in also ICar
            ICar carFromICar1 = new ElectricCarFromICar();
            ICar carFromICar2 = new PetrolCarFromICar();

            carFromICar1.Accelerate();
            carFromICar2.Accelerate();

        }

        // Polymorphic method : Polymorphism gives you the ability to pass any class that implements the ICar interface
        // to the method AccelerateCar(ICar car)
        private static void AccelerateCar(ICar car) // Overloaded method with parameter ICar car
        {
            car.Accelerate();
        }

        // Polymorphic method : Polymoprhism works in such a way that every object stores a reference to its original type
        private static void AccelerateCar(Car car) // Overloaded method with parameter Car car
        {
            car.Accelerate();
            // Here C# checks the initial type of the object car
            // Then it finds the method "Accelerate" in that class and calls it
            // If there are no overrides of this method in the "real" class,
            // the implementation from the parent class is used
        }
    }
}