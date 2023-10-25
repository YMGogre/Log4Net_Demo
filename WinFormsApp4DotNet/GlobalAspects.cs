/**
 * @brief 该源代码文件用于添加项目范围内的所有切面
 */

using PostSharp.Patterns.Diagnostics;
using PostSharp.Extensibility;

// 以下代码将日志记录添加到除私有方法和属性 getter 之外的所有方法中。您可以编辑此代码以针对与您的场景相关的方法。
[assembly: Log(AttributePriority = 1, AttributeTargetMemberAttributes = MulticastAttributes.Protected | MulticastAttributes.Internal | MulticastAttributes.Public)]
[assembly: Log(AttributePriority = 2, AttributeExclude = true, AttributeTargetMembers = "get_*")]
// PostSharp 现在将在由 Logging 切面标记目标的所有方法的执行前后、抛出未经处理的异常等情况添加日志记录。

// 您还可以通过 AttributeTargetTypes 和 AttributeTargetMembers 属性来指定应用日志记录的特定命名空间、类和方法。
// 以下代码指定记录 MyNamespace.MyClass.MyMethod 方法的调用：
[assembly: Log(AttributeTargetTypes = "MyNamespace.MyClass", AttributeTargetMembers = "MyMethod")]
// 上面这条语句仅作示例，本项目中并没有 MyNamespace 命名空间

// 以下代码指定记录 MyNamespace 命名空间下的所有类的所有公共方法：
[assembly: Log(AttributeTargetTypes = "MyNamespace.*", AttributeTargetMemberAttributes = MulticastAttributes.Public)]