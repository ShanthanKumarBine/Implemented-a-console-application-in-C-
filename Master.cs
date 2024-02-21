using System;

public class Master : Student
{
    private string advisorFirstNameValue;
    private string advisorLastNameValue;

    public Master()
    {
    }

    public Master(
      string first,
      string last,
      int credits,
      bool isMale,
      DateTime entrance,
      bool isResident,
      Address homeAddress,
      PhoneNumber homePhone,
      PhoneNumber mobilePhone,
      string advisorFirst,
      string advisorLast)
      : base(first, last, credits, isMale, entrance, isResident, homeAddress, homePhone, mobilePhone)
    {
        this.AdvisorFirstName = advisorFirst;
        this.AdvisorLastName = advisorLast;
    }

    public string AdvisorFirstName
    {
        get => Util.Capitalize(this.advisorFirstNameValue);
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
            this.advisorFirstNameValue = value;
        }
    }

    public string AdvisorLastName
    {
        get => Util.Capitalize(this.advisorLastNameValue);
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
            this.advisorLastNameValue = value;
        }
    }

    public override string StudentType => nameof(Master);

    public override Decimal RegistrationFee => this.IsResident ? 300M : 900M;

    public override Decimal TuitionRate => this.IsResident ? 450M : 900M;

    public override string ToString() => base.ToString() + "  Advisor: " + this.AdvisorFirstName + " " + this.AdvisorLastName;
}

