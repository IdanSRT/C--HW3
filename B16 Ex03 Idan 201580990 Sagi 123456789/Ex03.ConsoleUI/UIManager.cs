﻿using System;
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

        //constractor for UIManager.
        public UIManager()
        {
            m_GarageManager = new GarageManager();
        }

        public void StartService()
        {
            GarageManager newGarageManager = this.m_GarageManager;
            bool isDone = false;
            while (isDone == false)
            {
                //user choose the service he wish for.
                eService serviceOptionChoose = ServiceOptionChoose(newGarageManager.m_ServiceList);
                switch (serviceOptionChoose)
                {
                    case eService.AddVehical: //1 
                        string VehicleLicenseNum = getNewLicenseNum();
                        int indexOnList = newGarageManager.IndexOfVehicle(VehicleLicenseNum);
                        if (indexOnList != -1)
                        {
                            Console.WriteLine("Vehicle L.N " + VehicleLicenseNum +
                        " is allready in the garage and his status is " + newGarageManager.VehicleList[indexOnList].VehicleStatus);
                        }
                        else
                        {
                            newGarageManager.VehicleList.Add(GetNewVehicleStatusInfo(VehicleLicenseNum));
                        }
                        break;
                    case eService.PrintVehicalList:
                        PrintVehicleList(newGarageManager);
                        break;
                    case eService.UpdateVehicleStatus:
                        UpdateVehicleStatus(newGarageManager);
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
                        PrintVehicleInfo(newGarageManager);
                        break;
                    case eService.Done:
                        Console.WriteLine("Thanks for using our service, have a nice day and good bye!");
                        isDone = true;
                        break;
                    default:
                        Console.WriteLine("Please choose a valide option from our service");
                        break;
                }
            }
        }
        //printing vehicle info
        private static void PrintVehicleInfo(GarageManager i_GarageManager)
        {
            string VehicleLicenseNum = getNewLicenseNum();
            int indexOnList = i_GarageManager.IndexOfVehicle(VehicleLicenseNum);
            if (indexOnList == -1)
            {
                Console.WriteLine("Vehicle L.N " + VehicleLicenseNum + " is not in the garage so we can't print his info");
            }
            else
            {
                i_GarageManager.PrintVehicleInfo(VehicleLicenseNum);
            }
            
            
        }

        //update the vehicle Status;
        private static void UpdateVehicleStatus(GarageManager i_GarageManager)
        {
            string VehicleLicenseNum = getNewLicenseNum();
            int indexOnList = i_GarageManager.IndexOfVehicle(VehicleLicenseNum);
            if (indexOnList == -1)
            {
                Console.WriteLine("Vehicle L.N " + VehicleLicenseNum + " is not in the garage ");
            }
            else
            {
                Console.WriteLine("choose the status you wish to update vehicle :\n" +
                            "(1)In repair  " + "(2)Repaired  " + "(3)Payed  " + "(any other key)other");
                string inputListStr = Console.ReadLine();
                switch (inputListStr)
                {
                    case "1":
                        i_GarageManager.UpdateVehicleStatus(VehicleLicenseNum, eVehicleStatus.InRepair);
                        break;
                    case "2":
                        i_GarageManager.UpdateVehicleStatus(VehicleLicenseNum, eVehicleStatus.Repaired);
                        break;
                    case "3":
                        i_GarageManager.UpdateVehicleStatus(VehicleLicenseNum, eVehicleStatus.Piad);
                        break;
                    default:
                        //do nothing , open for future options.
                        break;
                }
            }
        }

        //helper for printing vehicle list.
        private  static void PrintVehicleList(GarageManager i_GarageManager)
        {
            Console.WriteLine("choose what vehicle list you wish to print:\n" +
                         "(1)In repair  " + "(2)Repaired  " + "(3)Payed  " + "(4)All-not filterd  ");
            string inputListStr = Console.ReadLine();
            switch (inputListStr)
            {
                case "1":
                    i_GarageManager.PrintFilteredVehicleList(eVehicleStatus.InRepair);
                    break;
                case "2":
                    i_GarageManager.PrintFilteredVehicleList(eVehicleStatus.Repaired);
                    break;
                case "3":
                    i_GarageManager.PrintFilteredVehicleList(eVehicleStatus.Piad);
                    break;
                default:
                    i_GarageManager.PrintVehicleList();
                    break;
            }
        }

        //geting the license number from the user.
        private static string getNewLicenseNum()
        {
            string licenseNumber = "";
            Console.WriteLine("Enter your vehicle license number");
            string inputLicenseNumberStr = Console.ReadLine();
            while (inputLicenseNumberStr == "")
            {
                Console.WriteLine("Please enter a valide vehicle license number");
                inputLicenseNumberStr = Console.ReadLine();
                licenseNumber = inputLicenseNumberStr;
            }
            return licenseNumber;
        }

        //takeing a vehicle license number and creating a new vehicleStatusInfo.
        public VehicleStatusInfo GetNewVehicleStatusInfo(string i_LicenseNumber)
        {
            eVehicleType vehicleType = GetVehicleType();
            string vehicleOwnerName = GetVehicleOwnerName();
            string vehicleOwnerPhone = GetVehicleOwnerPhone();
            string modelName = GetVehicleModleName();
            eEnergyType energyType = getEnergyInput();
            float maxEnergy = ChooseNumOf("max energy of the vehicle (float)");
            float energyLeft = ChooseNumOf("energy Left in the vehicle (float)", 0, maxEnergy);
            List<Wheel> wheelList = GetWheelList();
            Vehicle newVehicle;
            switch (vehicleType)
            {
                case eVehicleType.MotoricCar:
                    eColor motorCarcolor = GetColor();
                    int motorCarNumOfDoors = GetNumOfDoors();
                    newVehicle = new Car(modelName, i_LicenseNumber, energyLeft, wheelList, energyType, maxEnergy, motorCarcolor, motorCarNumOfDoors);
                    break;
                case eVehicleType.ElectricCar:
                    eColor elctCarColor = GetColor();
                    int elctCarNumOfDoors = GetNumOfDoors();
                    newVehicle = new Car(modelName, i_LicenseNumber, energyLeft, wheelList, energyType, maxEnergy, elctCarColor, elctCarNumOfDoors);
                    break;
                case eVehicleType.MotoricBike:
                    eLisenceSize licenseSize = GetLicenseSize();
                    int engineCapacity = GetEngineCapacity();
                    newVehicle = new Motorcycle(modelName, i_LicenseNumber, energyLeft, wheelList, energyType, maxEnergy, licenseSize, engineCapacity);
                    break;
                case eVehicleType.ElecticBike:
                    eLisenceSize elctLicenseSize = GetLicenseSize();
                    int elctEngineCapacity = GetEngineCapacity();
                    newVehicle = new Motorcycle(modelName, i_LicenseNumber, energyLeft, wheelList, energyType, maxEnergy, elctLicenseSize, elctEngineCapacity);
                    break;
                case eVehicleType.Truck:
                    bool hasDangerouseMaterial = IsDangerouse();
                    float maxWeight = ChooseNumOf("max weight of the truck");
                    newVehicle = new Truck(modelName, i_LicenseNumber, energyLeft, wheelList, energyType, maxEnergy,hasDangerouseMaterial, maxWeight);
                    break;
                default:
                    newVehicle = new Vehicle(modelName, i_LicenseNumber, energyLeft, wheelList, energyType, maxEnergy);
                    break;
            }
            VehicleStatusInfo newVehicleStatusInfo = new VehicleStatusInfo(i_LicenseNumber, vehicleOwnerName, vehicleOwnerPhone, newVehicle);
            return newVehicleStatusInfo;
        }

        //check with the user if the truck is dangerouse.
        private bool IsDangerouse()
        {
            Console.WriteLine("Does the truck contain dangerouse metirials ? (Y/N)");
            bool IsDangerouse = false;
            bool goodInput = false;
            while (goodInput == false)
            {
                string inputIsDangerouse = Console.ReadLine();
                if ((inputIsDangerouse == "y") || (inputIsDangerouse == "Y"))
                {
                    IsDangerouse = true;
                }
                else if ((inputIsDangerouse == "n") || (inputIsDangerouse == "N"))
                {
                    IsDangerouse = false;
                }
                else
                {
                    Console.WriteLine("Please type 'Y' or 'N' , its dangerouse !");
                }
            }
            return IsDangerouse;
        }

        //get the engine capasitiy for the user.
        private int GetEngineCapacity()
        {
            int inputEngineCapacity = (int)ChooseNumOf("engine capacity");
            return inputEngineCapacity;
        }

        //get the license size from the user.
        private eLisenceSize GetLicenseSize()
        {
            eLisenceSize licenseSize = eLisenceSize.Other;
            Console.WriteLine("Choose the number of the license Size :\n"
                + "(1)A   " + "(2)A1   " + "(3)AB   " + "(4)B1   " + "(5)Other");
            string inputLicenseSizeStr = Console.ReadLine();
            switch (inputLicenseSizeStr)
            {
                case "1":
                    licenseSize = eLisenceSize.A;
                    break;
                case "2":
                    licenseSize = eLisenceSize.A1;
                    break;
                case "3":
                    licenseSize = eLisenceSize.AB;
                    break;
                case "4":
                    licenseSize = eLisenceSize.B1;
                    break;
                case "5":
                    licenseSize = eLisenceSize.Other;
                    break;
            }
            return licenseSize;
        }

        //get number of doors of the car from the user.
        private int GetNumOfDoors()
        {
            int inputNumOfDoors = (int)ChooseNumOf("number of doors for the car (2-5)");
            return inputNumOfDoors;
        }
        
        //get car color from the user.
        private eColor GetColor()
        {
            eColor inputColor= eColor.Other;
            Console.WriteLine("Choose the number of the car color :\n"
                + "(1)Yello  " + "(2)White  " + "(3)Red  " + "(4)Black  " + "(5)Other  ");
            string inputColorStr = Console.ReadLine();
            switch (inputColorStr)
            {
                case "1":
                    inputColor = eColor.Yellow;
                    break;
                case "2":
                    inputColor = eColor.White;
                    break;
                case "3":
                    inputColor = eColor.Red;
                    break;
                case "4":
                    inputColor = eColor.Black;
                    break;
                case "5":
                    inputColor = eColor.Other;
                    break;
            }
            return inputColor;
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
            for (int service = 0; service < i_ServiceList.Count; service++)
            {
                Console.WriteLine((service + 1) + ") " + i_ServiceList[service].ServiceString);
            }
            Console.WriteLine((i_ServiceList.Count + 1) + ") Finish");
            string inputNumStr = Console.ReadLine();
            int inputServiceNumInt;
            bool goodInput = int.TryParse(inputNumStr, out inputServiceNumInt);
            while (!goodInput || inputServiceNumInt < 1 || inputServiceNumInt > i_ServiceList.Count)
            {
                Console.WriteLine("Input is not valid. \nPlease choose a service number between the range " + 1 + " to " + i_ServiceList.Count + ":");
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
