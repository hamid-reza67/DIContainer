using System.Reflection;
using System.Runtime.CompilerServices;

public class MyDIContainer
{
    private readonly Dictionary<Type, Type> _registeredTypes;
    private readonly Dictionary<Type, object> _singletons = new();
    public MyDIContainer()
    {
        _registeredTypes = new Dictionary<Type, Type>();
    }
    public void Register<TInterface, TImplementation>() where TImplementation : TInterface
    {
        _registeredTypes[typeof(TInterface)] = typeof(TImplementation);
    }

    public void RegisterSingleton<TInterface, TImplementation>() where TImplementation : TInterface
    {
        Register<TInterface, TImplementation>();

        // add the type as singleton
        _singletons[typeof(TInterface)] = null;
    }

    public TInterface Resolve<TInterface>()
    {
        return (TInterface)Resolve(typeof(TInterface));
    }

    public object Resolve(Type type)
    {
        if (_registeredTypes.ContainsKey(type))
        {
            // singleton check before instace
            if (_singletons.TryGetValue(type, out var value) && value is not null)
                return _singletons[type];

            var implementationType = _registeredTypes[type];
            var constructor = implementationType.GetConstructors().First();
            var constructorParameters = constructor.GetParameters();
            object? instace = null;

            if (constructorParameters.Length == 0)
            {
                instace = Activator.CreateInstance(implementationType);
            }
            else
            {
                // if constructor has params
                var parameterInstances = GetConstructorParameters(constructorParameters);
                instace = Activator.CreateInstance(implementationType, parameterInstances.ToArray());
            }

            // add this instace to singleton dictionry
            TryAddWhenSingleton(type, instace);
            return instace;
        }

        throw new Exception($"The service {type.FullName} has not been registered!");
    }



    private List<Object> GetConstructorParameters(ParameterInfo[] constructorParameters)
    {
        var parameterInstances = new List<object>();
        foreach (var parameter in constructorParameters)
        {
            var parameterType = parameter.ParameterType;
            var parameterInstance = Resolve(parameterType);
            parameterInstances.Add(parameterInstance);
        }
        return parameterInstances;
    }

    private void TryAddWhenSingleton(Type type, object instance)
    {
        if (_singletons.ContainsKey(type))
            _singletons[type] = instance;
    }
}