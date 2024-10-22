using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Diagnostics;

namespace WPFAssignment.Models
{
    public class UserDetails
    {
        [Key]
        public int Id { get; set; } // Primary key
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } // Store hashed password
    }

    public static class UserRepository
    {
        // Validates the user's email and password
        public static bool ValidateUser(string email, string password)
        {
            using (var context = new AppDbContext())
            {
                var user = context.UserDetails.SingleOrDefault(u => u.Email == email);
                return user != null && BCrypt.Net.BCrypt.Verify(password, user.Password);
            }
        }

        // Adds a new user to the database
        public static bool AddUser(UserDetails user)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    // Check if user already exists
                    if (context.UserDetails.Any(u => u.Email == user.Email))
                    {
                        Console.WriteLine("User with this email already exists.");
                        return false; // Prevent duplicate registration
                    }

                    // Hash the password before saving
                    user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
                    context.UserDetails.Add(user);
                    context.SaveChanges(); // Save changes to the database
                    Debug.WriteLine("User added successfully.");
                    return true; // Indicate success
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding user: {ex.Message}");
                return false; // Indicate failure
            }
        }

        // Resets the user's password
        public static bool ResetPassword(string email, string newPassword)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    var user = context.UserDetails.SingleOrDefault(u => u.Email == email);
                    if (user != null)
                    {
                        user.Password = BCrypt.Net.BCrypt.HashPassword(newPassword);
                        context.SaveChanges(); // Save changes to the database
                        return true; // Indicate success
                    }
                    else
                    {
                        Console.WriteLine("User not found.");
                        return false; // Indicate failure
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error resetting password: {ex.Message}");
                return false; // Indicate failure
            }
        }

        // Retrieves all users from the database
        public static List<UserDetails> GetAllUsers()
        {
            using (var context = new AppDbContext())
            {
                return context.UserDetails.ToList(); // Return list of users
            }
        }
    }
}
