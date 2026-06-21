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

            //bool doctorFound = false;

            //foreach(var doctor in context.Doctors)
            //{

            //    if (doctor.doctorSpecialization == doctorSpecialization)
            //    {

            //        doctorFound = true;
            //        Console.WriteLine("ID=" + doctor.doctorId + ", Name=" + doctor.doctorName + ", Specialization=" + doctor.doctorSpecialization + ", Phone=" + doctor.doctorPhone + ", Email=" + doctor.doctorEmail + ", Consultation Fee=" + doctor.consultationFee);

            //    }

            //}
            //if (doctorFound == false)
            //{

            //    Console.WriteLine("No doctor found");
            //}
            

            //**********************************************************************************//

            // anothe way to solve question 4 by using LINQ
            
            var doctors = context.Doctors
                     .Where(item => item.doctorSpecialization == doctorSpecialization)
                     .ToList();

            if (doctors.Count > 0)
            {
                foreach (var doctor in doctors)
                {
                  
                    Console.WriteLine("ID=" + doctor.doctorId + ", Name=" + doctor.doctorName + ", Specialization=" + doctor.doctorSpecialization + ", Phone=" + doctor.doctorPhone + ", Email=" + doctor.doctorEmail + ", Consultation Fee=" + doctor.consultationFee);
                }
            }
            else
            {
                Console.WriteLine("No doctor found");
            }


        }
        //*******************************************************************************//


        //*********************************************************************************//

        public static void AddAvailableTimeSlotDoctor(HospitalContext context) //05
        {

            Console.WriteLine("Select a Doctor");

            foreach (var doctor in context.Doctors)
            {

             Console.WriteLine("ID=" + doctor.doctorId + ", Name=" + doctor.doctorName + ", Specialization=" + doctor.doctorSpecialization + ", Phone=" + doctor.doctorPhone + ", Email=" + doctor.doctorEmail + ", Consultation Fee=" + doctor.consultationFee);

            }

            Console.WriteLine("Enter ID Doctor you want:");

            int doctorId =int.Parse(Console.ReadLine());

            //var selectedDoctor = context.Doctors.FirstOrDefault(item => item.doctorId == doctorId);

            var selectedDoctor = context.Doctors.FirstOrDefault(item => item.doctorId == doctorId);

            if (selectedDoctor == null)
            {
                Console.WriteLine("Doctor not found");
                return;
            }

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


        //**************************************************************************//



        //**************************************************************************//

        //solving question 06 by LINQ

        public static void BookAppointment(HospitalContext context)//06
        {

            Console.WriteLine("Select paitent");

            foreach (var patient in context.Patients)
            {
                Console.WriteLine("ID=" + patient.patientId + ",Name=" + patient.patientName + ", Age = " + patient.patientAge + ", Gender = " + patient.patientGender +
                    ", Phone = " + patient.patientPhone + ", Email = " + patient.patientEmail + ", Blood Type = " + patient.patientBloodType);
            }

            Console.WriteLine("Enter Patient ID:");
            int patientId = int.Parse(Console.ReadLine());


            Console.WriteLine("Select Doctor");

            foreach (var doctor in context.Doctors)
            {
                Console.WriteLine("ID=" + doctor.doctorId + ", Name=" + doctor.doctorName + ", Specialization=" + doctor.doctorSpecialization + ", Phone=" + doctor.doctorPhone + ", Email=" + doctor.doctorEmail + ", Consultation Fee=" + doctor.consultationFee);
            }

            Console.WriteLine("Enter Doctor ID:");
            int doctorId = int.Parse(Console.ReadLine());

            Console.WriteLine("Available Slot");

            bool slotFound = false;

            foreach (var slot in context.AvailableSlots)
            {
                if (slot.doctorId == doctorId && slot.isBooked == false)
                {
                    slotFound = true;

                    Console.WriteLine("Slot ID=" + slot.slotId + ", Date=" + slot.slotDate + ", Time=" + slot.slotTime);
                }
            }

            if (slotFound == false)
            {
                Console.WriteLine("No Available slots for this doctor");
                return;
            }

            Console.WriteLine("Enter Slot ID:");
            int slotId = int.Parse(Console.ReadLine());

            var selectedSlot = context.AvailableSlots.FirstOrDefault(item => item.slotId == slotId);
            if (selectedSlot == null)
            {
                Console.WriteLine("Invalid or already booked slot");
                return;
            }

            int appointmentId = context.Appointments.Count + 1;

            context.Appointments.Add(
                new Appointment
                {
                    appointmentId = appointmentId,
                    patientId = patientId,
                    doctorId = doctorId,
                    appointmentDate = selectedSlot.slotDate,
                    appointmentTime = selectedSlot.slotTime,
                    status = "Scheduled"
                }
            );

            selectedSlot.isBooked = true;

            Console.WriteLine("Appointment Booked Successfully");
        }

        //*********************************************************************************************



        public static void CancelAppointment(HospitalContext context) //07
        {
            Console.WriteLine("Enter Appointment ID:");
            int appointmentId = int.Parse(Console.ReadLine());

            var selectedAppointment = context.Appointments
                .FirstOrDefault(item => item.appointmentId == appointmentId);

            if (selectedAppointment == null)
            {
                Console.WriteLine("Appointment not found");
                return;
            }

            if (selectedAppointment.status == "Cancelled")
            {
                Console.WriteLine("Appointment already cancelled");
                return;
            }

            if (selectedAppointment.status == "Completed")
            {
                Console.WriteLine("Cannot cancel completed appointment");
                return;
            }

            selectedAppointment.status = "Cancelled";

            var selectedSlot = context.AvailableSlots
                .FirstOrDefault(item =>
                    item.doctorId == selectedAppointment.doctorId &&
                    item.slotDate == selectedAppointment.appointmentDate &&
                    item.slotTime == selectedAppointment.appointmentTime);

            if (selectedSlot != null)
            {
                selectedSlot.isBooked = false;
            }

            Console.WriteLine("Appointment Cancelled Successfully");
        }

        public static void CreateMedicalRecord(HospitalContext context) //08
        {
            Console.WriteLine("Enter appointment Id");
            int appointmentId = int.Parse(Console.ReadLine());

            var selectedAppointment = context.Appointments
                .FirstOrDefault(item => item.appointmentId == appointmentId);

            if (selectedAppointment == null)
            {
                Console.WriteLine("Appointment not found");
                return;
            }

            if (selectedAppointment.status == "Cancelled")
            {
                Console.WriteLine("Cannot create a medical record for a cancelled appointment.");
                return;
            }

            if (selectedAppointment.status == "Completed")
            {
                Console.WriteLine("A medical record already exists for this appointment.");
                return;
            }

            decimal fee = context.Doctors
                .Where(d => d.doctorId == selectedAppointment.doctorId)
                .Select(d => d.consultationFee)
                .FirstOrDefault();

            Console.WriteLine("Enter Diagnosis:");
            string diagnosis = Console.ReadLine();

            Console.WriteLine("Enter Prescription:");
            string prescription = Console.ReadLine();

            Console.WriteLine("Enter visit date:");
            string visitDate = Console.ReadLine();

            int recordId = context.MedicalRecords.Count + 1;

            context.MedicalRecords.Add(
                new MedicalRecord
                {
                    recordId = recordId,
                    patientId = selectedAppointment.patientId,
                    doctorId = selectedAppointment.doctorId,
                    appointmentId = appointmentId,
                    diagnosis = diagnosis,
                    prescription = prescription,
                    visitDate = visitDate,
                    visitFee = fee
                }
            );

            selectedAppointment.status = "Completed";

            Console.WriteLine("Medical record created successfully");
        }


        public static void GeneratePatientMedicalHistory(HospitalContext context)//09
        {
            Console.WriteLine("\n=== Patient Medical History Report ===");

            Console.Write("Enter Patient ID: ");
            int patientId = int.Parse(Console.ReadLine());

            var patient = context.Patients.FirstOrDefault(p => p.patientId == patientId);

            if (patient == null)
            {
                Console.WriteLine("Patient not found");
                return;
            }

            var records = context.MedicalRecords
                .Where(r => r.patientId == patientId)
                .ToList();

            if (records.Count == 0)
            {
                Console.WriteLine("No medical records found for this patient");
                return;
            }

            Console.WriteLine($"\n--- Medical History for {patient.patientName} (ID: {patientId}) ---");

            foreach (var r in records)
            {
                var doctorName = context.Doctors
                    .Where(d => d.doctorId == r.doctorId)
                    .Select(d => d.doctorName)
                    .FirstOrDefault();

                Console.WriteLine("\n  Visit Date  : " + r.visitDate);
                Console.WriteLine("  Doctor      : " + doctorName);
                Console.WriteLine("  Diagnosis   : " + r.diagnosis);
                Console.WriteLine("  Prescription: " + r.prescription);
                Console.WriteLine("  Fee Charged : " + r.visitFee);
                Console.WriteLine("  --------------------------------");
            }

            decimal total = records.Sum(r => r.visitFee);

            Console.WriteLine("\nTOTAL AMOUNT CHARGED = " + total);
        }




        public static void DoctorWorkloadAndRevenueSummary(HospitalContext context)//10
        {
            Console.WriteLine("\n=== Doctor Workload & Revenue Summary ===");

            if (context.Doctors.Count == 0)
            {
                Console.WriteLine("No doctors found");
                return;
            }

            if (context.Appointments.Count == 0)
            {
                Console.WriteLine("No appointments recorded yet");
                return;
            }

            var summary = context.Doctors
                .Select(d => new
                {
                    d.doctorId,
                    d.doctorName,
                    d.doctorSpecialization,

                    completed = context.Appointments
                        .Count(a => a.doctorId == d.doctorId && a.status == "Completed"),

                    cancelled = context.Appointments
                        .Count(a => a.doctorId == d.doctorId && a.status == "Cancelled"),

                    revenue = context.MedicalRecords
                        .Where(r => r.doctorId == d.doctorId)
                        .Sum(r => r.visitFee)
                })
                .OrderByDescending(x => x.revenue)
                .ToList();

            int rank = 1;

            foreach (var d in summary)
            {
                Console.WriteLine("\n------------------------------------");
                Console.WriteLine("Rank: " + rank);
                Console.WriteLine("Doctor Name: " + d.doctorName);
                Console.WriteLine("Specialization: " + d.doctorSpecialization);
                Console.WriteLine("Completed Appointments: " + d.completed);
                Console.WriteLine("Cancelled Appointments: " + d.cancelled);
                Console.WriteLine("Total Revenue: " + d.revenue);
                Console.WriteLine("------------------------------------");

                rank++;
            }

            Console.WriteLine("\nReport Generated Successfully");
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
                        AddAvailableTimeSlotDoctor(context);
                        break;

                    case 6:
                        BookAppointment(context);
                        break;

                    case 7:
                        CancelAppointment(context);
                       
                        break;

                    case 8:
                        CreateMedicalRecord(context);
                        break;

                    case 9:
                        GeneratePatientMedicalHistory(context);
                        break;
                    case 10:
                        DoctorWorkloadAndRevenueSummary(context);
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