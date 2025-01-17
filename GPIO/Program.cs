﻿//---------------------------------------------------------------------------------
// Copyright (c) July 2021, devMobile Software
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
//---------------------------------------------------------------------------------
using System;
using System.Device.Gpio;
using System.Threading;

namespace devMobile.NetCore.GPIO
{
	class Program
	{
		const int ButtonPinNumber = 5;
		const int LedPinNumber = 16;

		static void Main(string[] args)
		{
			try
			{
				GpioController controller = new GpioController(PinNumberingScheme.Logical);

				controller.OpenPin(ButtonPinNumber, PinMode.InputPullUp);
				controller.OpenPin(LedPinNumber, PinMode.Output);

				while (true)
				{
					if (controller.Read(ButtonPinNumber) == PinValue.High)
					{
						if (controller.Read(LedPinNumber) == PinValue.Low)
						{
							controller.Write(LedPinNumber, PinValue.High);
						}
						else
						{
							controller.Write(LedPinNumber, PinValue.Low);
						}
					}
					Thread.Sleep(100);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
	}
}
