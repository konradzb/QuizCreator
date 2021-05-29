using System;
using System.Collections.Generic;

//Car Rental model
namespace Cars.Model
{
    public record CarRental
    {
        public int Id { get; init; }
        public DateTime RentalTimeStart { get; set; }
        public DateTime RentalTimeEnd { get; set; }
        public double Price { get; set; }

        public int ClientId { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public int EmployeeId { get; set; }

        public CarRental(int id, int clientId, int carId, int employeeId, DateTime rentalTimeStart, DateTime rentalTimeEnd, double price)
        {
            Id = id;
            ClientId = clientId;
            CarId = carId;
            EmployeeId = employeeId;
            RentalTimeStart = rentalTimeStart;
            RentalTimeEnd = rentalTimeEnd;
            Price = price;
        }
    }
}

