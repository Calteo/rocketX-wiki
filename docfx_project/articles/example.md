# Example
This is a quick example the use this component.

## Sample object
Have a look at this class.

```
class DataContainer
{   
  public string Name { get; set; }
  public int ZipCode { get; set; }  
  [NotSerialized] 
  public string Passcode { get; set; }
  
  public FunkyData OtherData1 { get; private set; }
  public FunkyData OtherData2 { get; set; }
}
```
Here the properties `Name` and `ZipCode` get serialized. 
`Passcode` is obmitted due to the <xref:Toolbox.Xml.Serialization.NotSerializedAttribute> attribute. 
While `OtherData1` and `OtherData2` will be included if `FunkyData` has a default constructor. 
For the content of `FunkyData` the same rules apply.
    
## Usage
Simply create a instance of <xref:Toolbox.Xml.Serialization.XmlFormatter`1> and use the methods.

```
var myObject = new MyObject(); // or do your own thing
var formatter = new XmlFormatter<MyObject>();
formatter.Serialize(myObject, "myObjectFile.xml");
```

to serialize and

```
var formatter = new XmlFormatter<MyObject>();
var myObject = formatter.Deserialize("myObjectFile.xml");
```

to deserialize.