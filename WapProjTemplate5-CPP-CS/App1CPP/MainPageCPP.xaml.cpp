//
// MainPageCPP.xaml.cpp
// Implementation of the MainPageCPP class.
//

#include "pch.h"
#include "MainPageCPP.xaml.h"

using namespace App1CPP;

using namespace Platform;
using namespace Windows::Foundation;
using namespace Windows::Foundation::Collections;
using namespace Windows::UI::Xaml;
using namespace Windows::UI::Xaml::Controls;
using namespace Windows::UI::Xaml::Controls::Primitives;
using namespace Windows::UI::Xaml::Data;
using namespace Windows::UI::Xaml::Input;
using namespace Windows::UI::Xaml::Media;
using namespace Windows::UI::Xaml::Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

MainPageCPP::MainPageCPP()
{
	InitializeComponent();
}


void App1CPP::MainPageCPP::Button_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{
	textBox1->Text = L"Hello, World!";
}
