#pragma once

using namespace System;
using namespace System::ComponentModel;
using namespace System::Collections;
using namespace System::Windows::Forms;
using namespace System::Data;
using namespace System::Drawing;


namespace Controls {

	/// <summary>
	/// ControlsControl 摘要
	/// </summary>
	///
	/// 警告: 如果更改此类的名称，则需要更改
	///          与此类所依赖的所有 .resx 文件关联的托管资源编译器工具的
	///          “资源文件名”属性。否则，
	///          设计器将不能与此窗体的关联
	///          本地化资源正确交互。
	public ref class ControlsControl : public System::Windows::Forms::UserControl
	{
	public:
		ControlsControl(void)
		{
			InitializeComponent();
			//
			//TODO: 在此处添加构造函数代码
			//
		}

	protected:
		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		~ControlsControl()
		{
			if (components)
			{
				delete components;
			}
		}

	private:
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		System::ComponentModel::Container^ components;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// 设计器支持所需的方法 - 不要
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		void InitializeComponent(void)
		{
			this->SuspendLayout();
			// 
			// ControlsControl
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 12);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->Name = L"ControlsControl";
			this->Load += gcnew System::EventHandler(this, &ControlsControl::ControlsControl_Load);
			this->ResumeLayout(false);

		}
#pragma endregion
	private: System::Void ControlsControl_Load(System::Object^  sender, System::EventArgs^  e) {
			 }
	};
}
