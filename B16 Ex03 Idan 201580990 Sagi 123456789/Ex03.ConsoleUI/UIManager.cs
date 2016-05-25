using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;


namespace Ex03.ConsoleUI
{
    public enum eStatus
    {
        InRepair,
        Repaired,
        Piad
    }

    class UIManager
    {
        private GarageManager m_GarageManager;

        public static void StartService()
        {
            GarageManager newGarageManager = new GarageManager();
            newGarageManager.ServiceList.Add(new Service(("Enter a new car for repairing in the garage."), eService.AddVehical));
            newGarageManager.ServiceList.Add(new Service(("Print vehicle List in the Garage."), eService.PrintVehicalList));
            newGarageManager.ServiceList.Add(new Service(("Update vehicle status in the garage."), eService.UpdateVehicleStatus));
            newGarageManager.ServiceList.Add(new Service(("Fill air in the Vehicle wheels."), eService.FillAirInWheels));
            newGarageManager.ServiceList.Add(new Service(("Fuel up vehicle feul tank."), eService.FuelUpTank));
            newGarageManager.ServiceList.Add(new Service(("Charge up vehicle battery."), eService.ChargeUpBattery));
            newGarageManager.ServiceList.Add(new Service(("Print vehicle full info and status."), eService.PrintVehicleInfo));

            eService serviceOptionChoose = ServiceOptionChoose(newGarageManager.m_ServiceList);
            
            switch (serviceOptionChoose)
            {
                case eService.AddVehical: //1                    
                    newGarageManager.VehicleList.Add(getNewVehicleStatusInfo());                   
                    break;
                case eService.PrintVehicalList:
                    Console.WriteLine("option 2 was picked");
                    break;
                case eService.UpdateVehicleStatus:
                    Console.WriteLine("option 3 was picked");
                    break;
                case eService.FillAirInWheels:
                    Console.WriteLine("option 4 was picked");
                    break;
                case eService.FuelUpTank:
                    Console.WriteLine("option 5 was picked");
                    break;
                case eService.ChargeUpBattery:
                    Console.WriteLine("option 6 was picked");
                    break;
                case eService.PrintVehicleInfo:
                    Console.WriteLine("option 7 was picked");
                    break;
                case eService.Done:
                    Console.WriteLine("Thanks for using our service, have a nice day and good bye!");
                    break;
                default:
                    Console.WriteLine("Please choose a valide option from our service");
                    break;
            }
           
        }

        private void getNewVehicleStatusInfo()
        {
            
            Console.WriteLine("Enter your vehicle license number");
            string inputLicenseNumberStr = Console.ReadLine();
            while (inputLicenseNumberStr == "" )
            {
                Console.WriteLine("Please enter a valide vehicle license number");
                inputLicenseNumberStr = Console.ReadLine();
            }
            int indexOnList = m_GarageManager.IndexOfVehicle(inputLicenseNumberStr);
            
            //vehicle is allready in the garage, printing the vehicle status.
            if (indexOnList != -1)
            {
                Console.WriteLine("Vehicle L.N " + inputLicenseNumberStr +
                    " is allready in the garage and his status is " + m_GarageManager.VehicleList[indexOnList].VehicleStatus);
            }
            //vehicle isnt in the garage and we start taking information for the new vehicle.
            else
            {
                AddNewVehicle(inputLicenseNumberStr);               
            }
           
        }

        private void AddNewVehicle(string i_LicenseNumber)
        {
            eVehicleType vehicleType = GetVehicleType();
            string vehicleOwnerName = GetVehicleOwnerName();
            string vehicleOwnerPhone = GetVehicleOwnerPhone();
            string modelName = GetVehicleModleName();
            eEnergyType energyType = getEnergyInput();
            float maxEnergy = ChooseNumOf("max energy of the vehicle (float)");
            float energyLeft = ChooseNumOf("energy Left in the vehicle (float)", 0, maxEnergy);
                      
            List<Wheel> wheelList = GetWheelList();
            Vehicle newVehicle = new Vehicle(modelName, i_LicenseNumber, energyLeft, wheelList, energyType, maxEnergy);
            VehicleStatusInfo newVehicleStatusInfo = new VehicleStatusInfo(i_LicenseNumber, vehicleOwnerName, vehicleOwnerPhone, newVehicle);
            AdditionalInfo(vehicleType, newVehicle);        
        }

        private void AdditionalInfo(eVehicleType vehicleType, Vehicle newVehicle)
        {
            
        }

        //geting vehicle model name from the user.
        private string GetVehicleModleName()
        {
            string inputModelName = "";
            //check if its not empty vehicle model name string
            while (inputModelName == "")
            {
                Console.WriteLine("Please type the vehicle owner name");
                inputModelName = Console.ReadLine();
            }
            return inputModelName;
        }
        
        //geting vehicle owner phone number from the user.
        private string GetVehicleOwnerPhone()
        {
            string inputVehicleOwnerPhoneStr = "";
            bool goodInputPhone = false;
            //check if its not empty string or not a number under the thought that there isnot '-' or ' ' in the string
            while (inputVehicleOwnerPhoneStr == "" && !goodInputPhone)
            {
                Console.WriteLine("Please type the vehicle owner phone number");
                inputVehicleOwnerPhoneStr = Console.ReadLine();
                int inputNumInt;
                goodInputPhone = int.TryParse(inputVehicleOwnerPhoneStr, out inputNumInt);
            }
            return inputVehicleOwnerPhoneStr;
        }

        //geting vehicle owner name for the user.
        private string GetVehicleOwnerName()
        {
            string inputVehicleOwnerNameStr = "";
            //check if its not empty name string
            while (inputVehicleOwnerNameStr == "")
            {
                Console.WriteLine("Please type the vehicle owner name");
                inputVehicleOwnerNameStr = Console.ReadLine();
            }
            return inputVehicleOwnerNameStr;
        }

        //geting the vehicle type from the user.
        private eVehicleType GetVehicleType()
        {
            eVehicleType newVehicleType;
            string inputVehicleType = "";
            Console.WriteLine("Choose the number of the vehicle type :");
            int counter = 1;
            foreach (eVehicleType vehicleType in eVehicleType.GetValues(typeof(eVehicleType)))
            {
                Console.WriteLine((counter + 1) + ")" + vehicleType);
            }
            switch (inputVehicleType)
            {
                case "1":
                    newVehicleType = eVehicleType.MotoricCar;
                    break;
                case "2":
                    newVehicleType = eVehicleType.ElectricCar;
                    break;
                case "3":
                    newVehicleType = eVehicleType.MotoricBike;
                    break;
                case "4":
                    newVehicleType = eVehicleType.ElecticBike;
                    break;
                case "5":
                    newVehicleType = eVehicleType.Truck;
                    break;
                default: //in case of new type of vehicle which still not implemented.
                    newVehicleType = eVehicleType.Else;
                    break;
            }
            return newVehicleType;
        }

        //adding wheels information from user
        private List<Wheel> GetWheelList()
        {
            List<Wheel> newWheelList = new List<Wheel>();
            float inputNumberOfWheels;
            inputNumberOfWheels = ChooseNumOf("number of wheels of the vehicle");
            for (int numOfWheel = 0; numOfWheel < inputNumberOfWheels; numOfWheel++)
            {
                Console.WriteLine("Wheel No." + (numOfWheel + 1) + " :");

                float inputMaxPossiblePressure;
                string inputWheelManufacture = "";
                float inputAirPressure;

                inputMaxPossiblePressure = ChooseNumOf("max possible air pressoure in wheel (float)");

                //check if its not empty  wheel manufacture name string                   
                while (inputWheelManufacture == "")
                {
                    Console.WriteLine("Please type the wheel No." + numOfWheel + " manufacture name");
                    inputWheelManufacture = Console.ReadLine();
                }

                inputAirPressure = ChooseNumOf("air pressoure in wheel No." + numOfWheel + "(float)", 0, inputMaxPossiblePressure);

                Wheel newWheel = new Wheel(inputWheelManufacture, inputAirPressure, inputMaxPossiblePressure);
                newWheelList.Add(newWheel);
            }
            return newWheelList;
        }

        //helper to get energy type from the user.
        private eEnergyType getEnergyInput()
        {
            Console.WriteLine("What energy type your vehicle use from the list, in case of other type just it's name:"
                + "\n -Electricity- -Octan95- -Octan96- -Octan98- -Soler- ");
            string inputEnergyTypeStr = Console.ReadLine();
            eEnergyType newEnergyType;
           
            switch (inputEnergyTypeStr)
            {
                case "Electricity":
                    newEnergyType = eEnergyType.Electricity;
                    break;
                case "Octan95":
                    newEnergyType = eEnergyType.Octan95;
                    break;
                case "Octan96":
                    newEnergyType = eEnergyType.Octan96;
                    break;
                case "Octan98":
                    newEnergyType = eEnergyType.Octan98;
                    break;
                case "Soler":
                    newEnergyType = eEnergyType.Soler;
                    break;
                default: //in case of new type of energy which still not implemented.
                    newEnergyType = eEnergyType.DeFault;
                    break;
            }
            return newEnergyType;
        }

        //UI for choosing one of the option in the serice enum list.
        public static eService ServiceOptionChoose(List<Service> i_ServiceList)
        {
            Console.WriteLine("Hello dear custumer and thanks for coming to our humble garage. \nPlease choose one of the following options:");
            for (int service = 1; service < i_ServiceList.Count; service++)
            {
                Console.WriteLine(service + ") " + i_ServiceList[service].ServiceString);
            }

            string inputNumStr = Console.ReadLine();
            int inputServiceNumInt;
            bool goodInput = int.TryParse(inputNumStr, out inputServiceNumInt);
            while (!goodInput || inputServiceNumInt < 1 || inputServiceNumInt > i_ServiceList.Count)
            {
                Console.WriteLine("Input is not valid. \nPlease choose a service number between the range " + 0 + " to " + i_ServiceList.Count + ":");
                inputNumStr = Console.ReadLine();
                goodInput = int.TryParse(inputNumStr, out inputServiceNumInt);
            }
            return (eService)inputServiceNumInt;
        }

        //helper to for taking floats input from user from a range of numbers.
        public static float ChooseNumOf(string numToChoose, float startRange, float endRange)
        {
            System.Console.WriteLine("Please choose the number of " + numToChoose + ", between the range " + startRange + " to " + endRange + " (and then press 'enter'):");
            string inputNumStr = Console.ReadLine();
            float inputNumFloat;
            bool goodInput = float.TryParse(inputNumStr, out inputNumFloat);
            while (!goodInput || inputNumFloat < startRange || inputNumFloat > endRange)
            {
                Console.WriteLine("Input is not valid. \nPlease choose a number between the range " + startRange + " to " + endRange + ":");
                inputNumStr = Console.ReadLine();
                goodInput = float.TryParse(inputNumStr, out inputNumFloat);
            }

            return inputNumFloat;
        }

        //helper to for taking floats input from user.
        public static float ChooseNumOf(string numToChoose)
        {
            System.Console.WriteLine("Please choose the number of " + numToChoose + " :");
            string inputNumStr = Console.ReadLine();
            float inputNumFloat;
            bool goodInput = float.TryParse(inputNumStr, out inputNumFloat);
            while (!goodInput)
            {
                Console.WriteLine("Input is not valid. \nPlease choose a valide " + numToChoose + " :");
                inputNumStr = Console.ReadLine();
                goodInput = float.TryParse(inputNumStr, out inputNumFloat);
            }

            return inputNumFloat;
        }
    }
}
