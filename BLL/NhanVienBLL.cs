using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class NhanVienBLL
    {
        private NhanVienAccess _nhanVienAccess;

        // Constructor to initialize the NhanVienAccess class
        public NhanVienBLL()
        {
            _nhanVienAccess = new NhanVienAccess();
        }


        // Method to get an employee by ID
        public NhanVien GetNhanVienById(int maNhanVien)
        {
            try
            {
                // Check for valid employee ID
                if (maNhanVien <= 0)
                {
                    return null; // Invalid ID, return null or handle accordingly
                }

                // Call the Data Access Layer method to get the employee by ID
                return _nhanVienAccess.GetNhanVienById(maNhanVien);
            }
            catch (Exception ex)
            {
                // Log the error or handle the exception
                Console.WriteLine("Error in GetNhanVienById: " + ex.Message);
                return null; // Return null in case of an error
            }
        }


        // Method to load all employees
        public List<NhanVien> LoadNhanVien()
        {
            try
            {
                // Call the Data Access Layer method to get the list of employees
                return _nhanVienAccess.LoadNhanVien();
            }
            catch (Exception ex)
            {
                // Log the error or handle the exception (depending on your logging strategy)
                Console.WriteLine("Error in LoadNhanVien: " + ex.Message);
                return new List<NhanVien>(); // Return an empty list if there's an error
            }
        }

        // Method to add a new employee
        public string AddNhanVien(NhanVien nhanVien)
        {
            try
            {
                // Perform any business validation if needed (e.g., check for duplicate data)
                if (nhanVien == null)
                {
                    return "Invalid employee data";
                }

                // Call the Data Access Layer method to add the employee
                return _nhanVienAccess.AddNhanVien(nhanVien);
            }
            catch (Exception ex)
            {
                // Log the error or handle the exception
                Console.WriteLine("Error in AddNhanVien: " + ex.Message);
                return "Error adding employee";
            }
        }

        // Method to update an existing employee
        public string UpdateNhanVien(NhanVien nhanVien)
        {
            try
            {
                // Perform business validation if needed (e.g., check if the employee exists)
                if (nhanVien == null || nhanVien.MaNhanVien <= 0)
                {
                    return "Invalid employee data";
                }

                // Call the Data Access Layer method to update the employee
                return _nhanVienAccess.UpdateNhanVien(nhanVien);
            }
            catch (Exception ex)
            {
                // Log the error or handle the exception
                Console.WriteLine("Error in UpdateNhanVien: " + ex.Message);
                return "Error updating employee";
            }
        }

        // Method to delete an employee
        public string DeleteNhanVien(int maNhanVien)
        {
            try
            {
                // Perform business validation if needed (e.g., check if the employee exists)
                if (maNhanVien <= 0)
                {
                    return "Invalid employee ID";
                }

                // Call the Data Access Layer method to delete the employee
                return _nhanVienAccess.DeleteNhanVien(maNhanVien);
            }
            catch (Exception ex)
            {
                // Log the error or handle the exception
                Console.WriteLine("Error in DeleteNhanVien: " + ex.Message);
                return "Error deleting employee";
            }
        }
    }
}
