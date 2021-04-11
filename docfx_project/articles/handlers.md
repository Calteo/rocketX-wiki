# Handlers
With handlers you can adopt the process in various ways.

## Sample object
Have a look at this class.

```
class DataContainer
{   
  public string Name { get; set; }

  [NotSerialized]
  public int ZipCode { get; set; }  

  
}
```
Here the property `Name` gets serialized and `ZipCode` not. Maybe, because we want to apply some special encoding on it.
    
## Implementation
You can implement handlers at four points in the process.
- Just before serialization of an object.
- Just after serialization of an object.
- Just before deserialization of an object.
- Just after deserialization of an object.

They are implemented as methods in your object with a signature 
```
void MethodNameOfYourChoice(Dictionary<string, string> data)
```
Every method must be decorated with an attribute (from the usual serialisation, so there documentation does not apply here).
The passed data will be also serialized with the object. But it only makes sense to polulate it in the 
before the serilization take place.

|Action|Attribute|
|------|-----|
|before serialization|OnSerializingAttribute|
|after serialization|OnSerializedAttribute|
|before deserialization|OnDeserializingAttribute|
|after deserialization|OnDeserializedAttribute|

So the example code might look like this
```
    [OnSerializing]
    private void OnSerializing(Dictionary<string, string> data)
    {
        // Not so sophisticated encoding...
        data["EncodedZip"] = ZipCode.ToString();
    }

    [OnSerialized]
    private void OnSerialized(Dictionary<string, string> data)
    {
        // Nothing to do here, so this one could be obmitted
        // The data is already written, so changing it here will do nothing.
    }

    [OnDeserializing]
    private void OnDeserializing(Dictionary<string, string> data)
    {
        // Nothing to do here, so this one could be obmitted
        // The data is already read, so changes will get to the last handler.
        // The object is already constructed, but the properties have not been set.
    }

    [OnDeserialized]
    private void OnDeserialized(Dictionary<string, string> data)
    {
        // The object is already constructed and the properties have been set.

        // reverse the encoding...
        ZipCode = int.Parse(data["EncodedZip"]);
    }
``` 