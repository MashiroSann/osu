# OsuUiKit（中文说明）

`OsuUiKit` 是从 `osu!` 主工程中拆分出来的 UI 控件库，目标是让控件可以被其他 .NET 项目直接引用并复用。

## 目录说明

- `src/OsuUiKit`：控件库源码（类库）。
- `src/OsuUiKit.Demo`：最小示例工程，可用于集成后本地验证。

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

## 示例工程

运行示例：

```bash
dotnet run --project /home/runner/work/osu/osu/src/OsuUiKit.Demo/OsuUiKit.Demo.csproj
```

## 详细导入与调用文档

请阅读：[`导入与调用控件.md`](./导入与调用控件.md)
