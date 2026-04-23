# OsuUiKit（中文说明）

`OsuUiKit` 是从 `osu!` 主工程中拆分出来的 UI 控件库，目标是让控件可以被其他 .NET 项目直接引用并复用。

## 目录说明

- `src/OsuUiKit`：控件库源码（类库）。
- `List.md`：可调用控件清单（控件名、调用方式、命名空间）。
- `使用说明.md`：导入与使用说明。

## 依赖关系（已补齐）

`OsuUiKit` 中大量控件基于以下命名空间实现：

- `osu.Framework.*`（渲染、输入、Drawable 基础能力）
- `osu.Game.*`（Overlay、Localisation、InputBindings、部分工具类型等）
- `ppy.osu.Game.Resources`（字体与图标等资源）

为保证该库在其他项目中“下载后可直接调用”，当前 `OsuUiKit.csproj` 已声明：

- `ppy.osu.Framework`
- `ppy.osu.Game`
- `ppy.osu.Game.Resources`

## 快速开始

1. 将 `src/OsuUiKit` 拷贝到你的解决方案（或作为子模块引用）。
2. 在你的应用项目中添加对 `OsuUiKit.csproj` 的 `ProjectReference`。
3. 还原并构建：

```bash
dotnet restore
dotnet build
```

## 详细文档

- 仓库根目录：[`使用说明.md`](../../使用说明.md)
- 仓库根目录：[`List.md`](../../List.md)
