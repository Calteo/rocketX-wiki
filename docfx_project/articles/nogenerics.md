# Usage without generics
You can to use a version without the generic parameter, i.e. if you get the type as a variable of `Type`.
The class to use ist <xref:Toolbox.Xml.Serialization.XmlFormatter>.

```
var myObject = ...; // or do your own thing
var formatter = new XmlFormatter(myObject.GetType());
formatter.Serialize(myObject, "myObjectFile.xml");
```

to serialize and

```
var formatter = new XmlFormatter(typeof(MyObject));
var myObject = (MyObject)formatter.Deserialize("myObjectFile.xml");
```

to deserialize.
