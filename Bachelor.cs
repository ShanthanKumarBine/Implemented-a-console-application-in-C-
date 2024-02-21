using System;

public class Bachelor : Student
{
    public Bachelor()
    {
    }

    public Bachelor(
      string first,
      string last,
      int credits,
      bool isMale,
      DateTime entrance,
      bool isResident,
      Address homeAddress,
      PhoneNumber homePhone,
      PhoneNumber mobilePhone,
      bool scholar)
      : base(first, last, credits, isMale, entrance, isResident, homeAddress, homePhone, mobilePhone)
    {
        this.Scholar = scholar;
    }

    public bool Scholar { get; set; }

    public override string StudentType => nameof(Bachelor);

    public override Decimal RegistrationFee => this.IsResident ? 200M : 600M;

    public override Decimal TuitionRate => this.IsResident ? 350M : 700M;

    public override string ToString() => this.Scholar ? base.ToString() + "  Scholar" : base.ToString();
}

