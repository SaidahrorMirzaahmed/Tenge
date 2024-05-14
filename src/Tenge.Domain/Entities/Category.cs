using Arcana.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tenge.Domain.Entities;

public class Category : Auditable
{
    public string Name {  get; set; }
}
