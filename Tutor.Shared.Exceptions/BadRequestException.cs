﻿namespace Tutor.Shared.Exceptions;

public class BadRequestException : Exception
{
	public BadRequestException(string message) : base(message)
	{

	}
}
