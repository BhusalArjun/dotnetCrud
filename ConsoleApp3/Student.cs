using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp3
{
    internal class Student
    {
        int rollNo;
        string name, address, mobile;

        public Student() { }

        public Student(int rollNo, string name, string address, string mobile)
        {
            this.rollNo = rollNo;
            this.name = name;
            this.address = address;
            this.mobile = mobile;
        }
        public void read()
        {
            Console.WriteLine("Enter roll number,name, address and mobile number for student:");
            rollNo = int.Parse(Console.ReadLine());
            name = Console.ReadLine();
            address = Console.ReadLine();
            mobile = Console.ReadLine();

        }
        public void displayStudent()
        {
            Console.WriteLine(rollNo + "\t" + name + "\t" + address + "\t" + mobile +"\t");
        }
        public void insertStudent()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-9F1PO4V\\SQLEXPRESS01;Initial Catalog=Aadim;Integrated Security=True");
            con.Open();
            string cmdStr = "Insert into student values(" + rollNo + ",'" + name + "','" + address + "','" + mobile + "')";
            SqlCommand cmd = new SqlCommand(cmdStr, con);
            cmd.ExecuteNonQuery();
            con.Close();



        }
        public void updateStudent(int rollNo, string mobile)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-9F1PO4V\\SQLEXPRESS01;Initial Catalog=Aadim;Integrated Security=True");
                con.Open();
                string cmdStr = "Update Student set Mobile='" + mobile + "'where RollNo=" + rollNo;
                SqlCommand cmd = new SqlCommand(cmdStr, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Found:" + ex.Message);
            }
        }
        public static void displayAllStudent()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-9F1PO4V\\SQLEXPRESS01;Initial Catalog=Aadim;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection= con;
            string query = "Select * From Student";
            cmd.CommandText = query;
            SqlDataAdapter da= new SqlDataAdapter(cmd);
            DataTable dt= new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                Student s= new Student(int.Parse(dr[0].ToString()), dr[1].ToString(), dr[2].ToString(), dr[3].ToString());
                s.displayStudent();
            }

        }
    }
}
