using System;
using System.Collections.Generic;

namespace person_crud.DataAccess.DataModel;

public partial class Person
{
    public int PersonId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Age { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public bool IsEnabled { get; set; }
}
