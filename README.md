# String data list

It's a kind of dynamic enum enabler.
Let say you want to allow your designer to edit some string properties in your project (you, fool) but there are only a limited amount of allowed strings, like characters names, seasons or anything, and for whatever reason, you don't want or cannot use enums.
Or maybe you have a list of data, and you don't want to have a "name" property of each data nor you want the list to display "Element 0", "Element 1", but instead you want to use your own names: for instance "Cat, dog, unicorn, etc".

This is the asset for you. You can store the value as a string or an integer and display it as a string picked in an existing external list.

![Customise names of elements in an array](Documentation~/images/list-naming.jpg)

## Description

There are two attributes and drawer:
- [Select("characters")]: allow to enter a string by selecting a name in the list
- [DataList("season")]: allow to customise the element names of a list

The parameter in parenthesis is used to load a TXT file of that name from the **datalist** folder in the **Resources** of your project.

In those examples, there would be a characters.txt file and a season.txt file.

## Usage

### String or int Select

1. Create a TXT file in a Resources/datalist folder in your project, named after the data your want to enter, for instance animal.txt
2. Add one line per data
3. Add the ```[Select]``` attribute on a string (or an int) property to be able to enter a string only from that file content as below

 ```C#
 [SerializeField]
 [Select("animal")]
 string favoriteAnimal;
  ```
  OR

  ```C#
 [SerializeField]
 [Select("animal")]
 int favoriteAnimalId;
  ```

![demo](Documentation~/images/string-select.jpg)

**Caution**: if you use an int field, the value will still be the same integer even if you change the lines TXT file! (order of lines and/or content)

### List element customisation

1. Create a TXT file in a Resources/datalist folder in your project, named after the names kind your want, for instance animal.txt
2. Add one line per data
3. Create a child class from the generic  ```DataList<T>``` provided class
3. Add the ```[DataList]``` attribute to a list or array property on another MonoBehaviour or ScriptableObject class

  ```C#
  [System.Serializable]
  class AnimalList : DataList<Animal> { }

  [SerializeField]
  [Select("animal")]
  string favoriteAnimal;
  ```

![Customise names of elements in an array](Documentation~/images/list-naming-short.jpg)

**Caution**: the order of the names in the list matches the order of the animal.txt file: if you change the file, the order will also be changed in the editor.

## Demo

A demo is present under the Sample folder.

1. Load the scene
2. Select the only game object
3. In the inspector, select your favorite animal from the list, and add and/or remove characteristics.

## FAQ

### I have added [Select("MyCoolList")] before a string/int property but it still shows only a regular field, what is wrong?

Ensure the ```MyCoolList.txt``` asset exists in a ```Resources``` folder or your project and the file is not empty. If no file is found or the file is empty, this asset uses the regular property field.

If you want to make sure the attribute is correctly used, you can add a second parameter that displays a warning if something is missing:

 ```C#
 [SerializeField]
 [Select("MyCoolList", true)]
 string coolStuff;
  ```

![warning when no file is found](Documentation~/images/warning.jpg)

### It still does not display the SelectDrawer/DataListDrawer!

Are you sure the inspector is not in Debug mode?
By the way, did you know that in Debug mode, you can Alt-Click on a property name to display the real exact property name?

![debug mode, no drawer](Documentation~/images/debug-mode.jpg)
