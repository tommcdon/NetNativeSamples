//
// MainPageCPP.xaml.h
// Declaration of the MainPageCPP class.
//

#pragma once

#include "MainPageCPP.g.h"

namespace App1CPP
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public ref class MainPageCPP sealed
	{
	public:
		MainPageCPP();

	private:
		void Button_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e);
	};
}
