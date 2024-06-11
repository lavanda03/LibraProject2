using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Common
{
	public class PasswordHasher
	{
		public static string ComputeSHA256Hash(string inputString)
		{
			using (SHA256 sha256 = SHA256.Create())
			{
				byte[] bytes = Encoding.UTF8.GetBytes(inputString);
				byte[] hashBytes = sha256.ComputeHash(bytes);

				StringBuilder stringBuilder = new StringBuilder();
				for (int i = 0; i < hashBytes.Length; i++)
				{
					stringBuilder.Append(hashBytes[i].ToString("x2"));
				}

				return stringBuilder.ToString();
			}
		}
	}
}
