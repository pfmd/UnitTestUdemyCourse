﻿using NUnit.Framework;
using System;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class ReservationTests
    {
        [Test]
        public void CanBeCancelledBy_UserIsAdmin_ReturnsTrue()
        {
            //Arrange
            var reservation = new Reservation();
            //Act
            var result = reservation.CanBeCancelledBy(new User { IsAdmin = true });
            //Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void CanBeCancelledBy_SameUserCancellingTheReservation_ReturnsTrue()
        {
            //Arrange
            User user = new User();
            var reservation = new Reservation{MadeBy=user};
            //Act
            var result = reservation.CanBeCancelledBy(user);
            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CanBeCancelledBy_AnotherUserCancellingTheReservation_ReturnsFalse()
        {
            //Arrange
            var reservation = new Reservation{MadeBy=new User()};
            //Act
            var result = reservation.CanBeCancelledBy(new User ());
            //Assert
            Assert.IsFalse(result);
        }
    }
}
