![preview](https://img.shields.io/badge/preview-orange.svg)
![version 0.0.1](https://img.shields.io/badge/version-0.0.1-blue.svg)
![in development](https://img.shields.io/badge/status-in%20development-blue.svg)
[![doc](https://img.shields.io/badge/documentation-darkgreen.svg)](https://nebukam.github.io/docs/unity/com.nebukam.signals/)

# N:Signals
#### Micro signal & messaging system for Unity

N:Signals is a micro library for lightweight, strongly-typed messassing manipulation.

### Concept

- A Signal is essentially a mini-dispatcher specific to one event, with its own array of listeners.
- A Signal gives an event a concrete membership in a class.
- Listeners subscribe to real objects.
- Signals are inspired by [C# events](https://en.wikipedia.org/wiki/C_Sharp_syntax#Events) and [signals/slots in Qt](https://en.wikipedia.org/wiki/Signals_and_slots).

---
## Hows

### Syntax
#### Without arguments

```C#
//FOO object
//Create signal
protected Signal m_beep = new Signal();
//Expose signal through ISignal interface (keeps Dispatch method internal)
public ISignal beep { get{ return m_beep;} }
...

//Subcribe to 'beep'
foo.beep.Add(callback);
...

//FOO object
//Notify all 'beep' subscribers.
m_beep.Dispatch();
```

#### With arguments

```C#
//As simple as without.
protected Signal<int, string> m_boop = new Signal<int, string>();
...
m_boop.Dispatch(777, "BOOP");
```

### Installation
> To be used with [Unity's Package Manager](https://docs.unity3d.com/Manual/upm-ui-giturl.html).  
> ⚠ [Git Dependency Resolver For Unity](https://github.com/mob-sakai/GitDependencyResolverForUnity) must be installed *before* in order to fetch nested git dependencies. (See the [Installation troubleshooting](#installation-troubleshooting) if you encounter issues).  

See [Unity's Package Manager : Getting Started](https://docs.unity3d.com/Manual/upm-parts.html)

---
## Credits

This library is inspired by the work of Robert Penner and his [AS3 Signals.](https://github.com/robertpenner/as3-signals).

---
## Installation Troubleshooting

After installing this package, Unity may complain about missing namespace references error (effectively located in dependencies). What [Git Dependency Resolver For Unity](https://github.com/mob-sakai/GitDependencyResolverForUnity) does, instead of editing your project's package.json, is create local copies of the git repo *effectively acting as custom local packages*.
Hence, if you encounter issues, try the following:
- In the project explorer, do a ```Reimport All``` on the **Packages** folder (located at the same level as **Assets** & **Favorites**). This should do the trick.
- Delete Library/ScriptAssemblies from you project, then ```Reimport All```.
- Check the [Resolver usage for users](https://github.com/mob-sakai/GitDependencyResolverForUnity#usage)
