using System;

public abstract class Student
{
    private string firstNameValue;
    private string lastNameValue;
    private int creditsValue;
    private DateTime entranceDateValue;
    public Student()
    {
    }

   public Student(
   string first,
   string last,
   int credits,
   bool isMale,
   DateTime entrance,
   bool isResident,
   Address homeAddress,
   PhoneNumber homePhone,
   PhoneNumber mobilePhone)
    {
        this.FirstName = first;
        this.LastName = last;
        this.Credits = credits;
        this.IsMale = isMale;
        this.IsResident = isResident;
        this.EntranceDate = entrance;
        this.HomeAddress = homeAddress;
        this.HomePhone = homePhone;
        this.MobilePhone = mobilePhone;
    }

    public string FirstName
    {
        get => Util.Capitalize(this.firstNameValue);
        set
        {
            value = value.Trim().ToUpper();
            if (value.Length < 1)
                throw new ApplicationException("First name is empty!");
            foreach (char ch in value)
            {
                if (ch < 'A' || ch > 'Z')
                    throw new ApplicationException("First name must consist of letters only!");
            }
            this.firstNameValue = value;
        }
    }
    public string LastName
    {
        get => Util.Capitalize(this.lastNameValue);
        set
        {
            value = value.Trim().ToUpper();
            if (value.Length < 1)
                throw new ApplicationException("Last name is empty!");
            foreach (char ch in value)
            {
                if (ch < 'A' || ch > 'Z')
                    throw new ApplicationException("Last name must consist of letters only!");
            }
            this.lastNameValue = value;
        }
    }
    public int Credits
    {
        get => this.creditsValue;
        set => this.creditsValue = value <= 21 && value >= 1 ? value : throw new ApplicationException("Credits taking must be between 1 and 21");
    }
    public bool IsMale { get; set; }
    public string Name => this.LastName + ", " + this.FirstName;
    public bool IsFemale
    {
        get => !this.IsMale;
        set => this.IsMale = !value;
    }
    public string Gender
    {
        get => this.IsMale ? "Male" : "Female";
        set
        {
            value = value.ToUpper();
            if (value == "MALE" || value == "M")
            {
                this.IsMale = true;
            }
            else
            {
                if (!(value == "FEMALE") && !(value == "F"))
                    throw new ApplicationException("Gender should be Male or Female!");
                this.IsMale = false;
            }
        }
    }
    public string Title => this.IsMale ? "Mr." : "Ms.";

    public string TitleName => this.Title + " " + this.Name;

    public bool IsResident { get; set; }

    public string Residency => this.IsResident ? "In-state" : "Out-state";

    public DateTime EntranceDate
    {
        get => this.entranceDateValue;
        set => this.entranceDateValue = !(value > DateTime.Now) ? value : throw new ApplicationException("Entrance date must be prior to today!");
    }

    public byte YearsOfStudy
    {
        get
        {
            if (this.EntranceDate == null)
            {
                throw new InvalidOperationException("Entrance date is not set.");
            }

            DateTime entranceDate = (DateTime)this.EntranceDate;

            TimeSpan difference = DateTime.Now - entranceDate;

            int yearsOfStudy = (int)Math.Floor(difference.TotalDays / 365.25);

            return (byte)yearsOfStudy;
        }
    }
    public Address HomeAddress { get; set; }

    public PhoneNumber HomePhone { get; set; }

    public PhoneNumber MobilePhone { get; set; }

    public abstract string StudentType { get; }

    public abstract Decimal RegistrationFee { get; }

    public abstract Decimal TuitionRate { get; }

    public Decimal Tuition => this.TuitionRate * (Decimal)this.Credits;

    public Decimal Total => this.RegistrationFee + this.Tuition;

    public override string ToString() => this.TitleName + "\t" + this.StudentType + ", " + this.Credits.ToString() + " credits, " + this.Residency + ", " + this.YearsOfStudy.ToString() + " years at CU\nRegistration: " + this.RegistrationFee.ToString("C") + "  Tuition: " + this.Tuition.ToString("C") + "  Total: " + this.Total.ToString("C") + "\n" + this.HomeAddress?.ToString() + "\t" + this.HomePhone.ToString() + "/" + this.MobilePhone.ToString();
}



  
     