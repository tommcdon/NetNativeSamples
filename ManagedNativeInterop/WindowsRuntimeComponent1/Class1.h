#pragma once

namespace WindowsRuntimeComponent1
{
    public ref class Class1 sealed
    {
    public:
        Class1();

		Platform::String^ GetFoo()
		{
			return L"Foo!";
		}
    };
}
