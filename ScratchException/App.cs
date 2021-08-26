using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ScratchException {
	class App {
		public void Run() {
			try {
				Exception inner = new Exception("inner");
				inner.Data.Add("1", "one");
				Exception main = new Exception("Main", inner);

				throw main;

			} catch (Exception ex) {
				Console.WriteLine(ProcessException(ex));

			}
		}


		private static string ProcessException(Exception ex) {
			if (ex == null) return string.Empty;

			string dateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

			StringBuilder sb = new StringBuilder($"[{dateTime}] EXCEPTION: AN EXCEPTION OCCURED.");
			sb.AppendLine("--------------------------------------");

			try {
				//skip the unhandled error, as we are only interested in the inner.
				if (ex.GetType().ToString() == "System.Web.HttpUnhandledException" & ex.InnerException != null) ex = ex.InnerException;

				while (ex != null) {
					sb.AppendLine($"Message: {ex.Message}");
					var st = ex.StackTrace == null ? "No stacktrace" : ex.StackTrace;
					sb.AppendLine($"Stack:   {st}");
					var t = ex.TargetSite == null ? "No targetsite" : ex.TargetSite.ToString();
					sb.AppendLine($"Target:  {t}");
					var s = ex.Source == null ? "No source" : ex.Source;
					sb.AppendLine($"Source:  {s}");

					if (ex.Data != null) {
						sb.AppendLine("Exception Data");
						foreach (DictionaryEntry d in ex.Data) {
							sb.AppendLine($"\tKey: [{d.Key}] Value: [{d.Value}]");
						}
					}
					ex = ex.InnerException;
					if (ex != null) {
						sb.AppendLine("INNER---------------------------------");
					}
				}

				sb.AppendLine("DONE----------------------------------");

				return sb.ToString();
			} catch (Exception innerEx) {
				string errstr = String.Format("Exception Occurred in ProcessException(Exception ex) during the writing of an exception\n\n\n{0}\n\n\nOriginal Exception\n\n\n{1}n\n\nInfo Before Inner Exception\n\n\n{2}",
				innerEx.ToString(),
				innerEx != null ? innerEx.ToString() : "NULL",
				sb.ToString());

				return errstr;
			}
		}
	}
}

