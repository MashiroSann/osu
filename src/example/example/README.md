# example

该目录用于提取 `OsuUiKit` 中可直接调用（public + 非抽象 + 继承 Drawable + 具有无参构造）的控件。

- 控件列表入口：`ControlExamples.GetAllCallableControlExamples()`
- 每个控件都会给出对应 C# 调用示例字符串：
  - `var control = new Namespace.ControlType();`

可用于在其他工程中直接枚举并批量展示调用方式。
