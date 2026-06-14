using Hospital_Management_System.Models;
using System.Timers;

namespace Hospital_Management_System
{
    internal class Program
    {
        public static void RegistrationPatient(HospitalContext context) //01
        {
            Console.WriteLine("Enter patient Name:");
            string patientName = Console.ReadLine();

            Console.WriteLine("Enter patient Age:");
            int patientAge = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter patient Gender:");
            string patientGender = Console.ReadLine();

            Console.WriteLine("Enter patient Phone:");
            string patientPhone = Console.ReadLine();

            Console.WriteLine("Enter patient Email:");
            string patientEmail = Console.ReadLine();

            Console.WriteLine("Enter patient Blood Type:");
            string patientBloodType = Console.ReadLine();

            int patientId = (context.Patients.Count) + 1;

            context.Patients.Add(

                new Patient
                {

                    patientId = patientId,

                    patientName = patientName,

                    patientAge = patientAge,

                    patientGender = patientGender,

                    patientPhone = patientPhone,

                    patientEmail = patientEmail,

                    patientBloodType = patientBloodType,

                }

            );

            Console.WriteLine("patient added Succesfully with ID" + patientId);
        }

        public static void AddNewDoctor(HospitalContext context) //02
        {
            Console.WriteLine("Enter doctor Name:");
            string doctorName = Console.ReadLine();

            Console.WriteLine("Enter doctor Specialization:");
            string doctorSpecialization = Console.ReadLine();

            Console.WriteLine("Enter doctor Phone:");
            string doctorPhone = Console.ReadLine();

            Console.WriteLine("Enter doctor Email:");
            string doctorEmail = Console.ReadLine();

            Console.WriteLine("Enter consultation Fee:");
            decimal consultationFee = decimal.Parse(Console.ReadLine());

            int doctorId = (context.Doctors.Count) + 1;

            context.Doctors.Add(

                new Doctor
                {
                    doctorId = doctorId,
                    doctorName = doctorName,
                    doctorSpecialization = doctorSpecialization,
                    doctorPhone = doctorPhone,
                    doctorEmail = doctorEmail,
                    consultationFee = consultationFee,


                }




                );

            Console.WriteLine("Doctors added Succesfully with ID" + doctorId);




        }
    

        

        public static void ViewAllPatients(HospitalContext context) //03
        {


            if (context.Patients.Count == 0)
            {
                Console.WriteLine("No patients found");
            }

            else
            {

                foreach(var patient in context.Patients)
                {

                    Console.WriteLine("ID=" + patient.patientId + ",Name=" + patient.patientName + ", Age = " + patient.patientAge + ", Gender = " + patient.patientGender +
                     ", Phone = " + patient.patientPhone + ", Email = " + patient.patientEmail + ", Blood Type = " + patient.patientBloodType);



                       
                }





            }




        }


        public static void ViewDoctorsSpecialization(HospitalContext context) //04
        {
            Console.WriteLine("Enter Specialization");
            string doctorSpecialization = Console.ReadLine();

            bool doctorFound = false;

            foreach(var doctor in context.Doctors)
            {

                if (doctor.doctorSpecialization == doctorSpecialization)
                {

                    doctorFound = true;
                    Console.WriteLine("ID=" + doctor.doctorId + ", Name=" + doctor.doctorName + ", Specialization=" + doctor.doctorSpecialization + ", Phone=" + doctor.doctorPhone + ", Email=" + doctor.doctorEmail + ", Consultation Fee=" + doctor.consultationFee);

                }
            
            }
            if (doctorFound == false)
            {

                Console.WriteLine("No doctor found");
            }




        }


        public static void AddAvailableimeSlotDoctor(HospitalContext context) //05
        {

            Console.WriteLine("Select a Doctor");

            foreach (var doctor in context.Doctors)
            {

             Console.WriteLine("ID=" + doctor.doctorId + ", Name=" + doctor.doctorName + ", Specialization=" + doctor.doctorSpecialization + ", Phone=" + doctor.doctorPhone + ", Email=" + doctor.doctorEmail + ", Consultation Fee=" + doctor.consultationFee);

            }

            Console.WriteLine("Enter ID Doctor you want:");

            int doctorId =int.Parse(Console.ReadLine());



            Console.WriteLine("Enter  slot Date");
            string slotDate = Console.ReadLine();


            Console.WriteLine("Enter  slot Time");
            string slotTime = Console.ReadLine();

            int newSlotId = context.AvailableSlots.Count() + 1;

            context.AvailableSlots.Add(


                new AvailableSlot
                {

                  slotId =newSlotId,

                 doctorId=doctorId,

                 slotDate= slotDate,

                 slotTime=slotTime,

                 isBooked=false,
                } );


            Console.WriteLine("Slot added Successfully");

        }





        static void Main(string[] args)
        {
            HospitalContext context = new HospitalContext();

            context.Patients = new List<Patient>();
            context.Doctors = new List<Doctor>();
            context.AvailableSlots = new List<AvailableSlot>();
            context.Appointments = new List<Appointment>();
            context.MedicalRecords = new List<MedicalRecord>();



            bool exit = false;

            while (exit == false)
            {
                Console.WriteLine("Welcome to the Hospiatal System");
                Console.WriteLine("Please Select an option");
                Console.WriteLine("1- Patient Registration");
                Console.WriteLine("2- Add a New Doctor");
                Console.WriteLine("3- View All Patients");
                Console.WriteLine("4- View All Doctors by Specialization");
                Console.WriteLine("5- Add an Available Time Slot for a Doctor");
                Console.WriteLine("6- Book an Appointment");
                Console.WriteLine("7- Cancel an Appointment");
                Console.WriteLine("8- Create a Medical Record After a Visit");
                Console.WriteLine("9- Generate a Patient Medical History Report");
                Console.WriteLine("10- Doctor Workload and Revenue Summary");
                Console.WriteLine("0-  Exit");


                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        RegistrationPatient(context);
                        break;

                    case 2:
                        AddNewDoctor(context);
                        break;
                    case 3:
                        ViewAllPatients(context);
                        break;

                    case 4:
                        ViewDoctorsSpecialization(context);
                        break;

                    case 5:
                        AddAvailableimeSlotDoctor(context);
                        break;

                    case 0:
                        exit = true;
                        break;

                    default:

                        Console.WriteLine("Invalid Option:Please Try Again");
                        break;
                }

                Console.WriteLine("press any key to continue......");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}