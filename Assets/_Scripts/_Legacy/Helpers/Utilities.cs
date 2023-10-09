using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utilities
{
	public static int GetIntegerFromInput(string input)
	{
		if(string.IsNullOrEmpty(input) == true)
		{
			return -1;
		}
		
		int result = 0;
		if(int.TryParse(input, out result) == false)
		{
			return -1;
		}

		return result;
	}
}
