using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace misty.Models {
	[AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
	public sealed class ValidateNeverAttribute : Attribute {
		public ValidateNeverAttribute() {
		}
	}
}
