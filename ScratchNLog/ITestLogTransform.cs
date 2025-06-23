using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScratchNLog {
	public interface ITestLogTransform {
		/// <summary>
		/// A method to return a transformed object for NLog logging.
		/// </summary>
		/// <returns></returns>
		/// <remarks>A method to call this and register the transformation has to happen at application startup.</remarks>
		object GetNLogTransformationObject();
	}
}
