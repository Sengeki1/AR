# Around the World

This project focuses on Augmented Reality, aiming to provide an in-depth understanding and intuitive exploration of this cutting-edge technology.

# Setting up Project

First we have to install Unity as our primary tool for development and open a new project as a 3D core. After doing that, we have to create a Vuforia developer account and get a free Vuforia App License key which will enable us to track the cube.
To set up the cube, firstly we have to create a database in the vufuria account page, setting each corresponding image side respectively to the cube. All left to do is download as a Unity package and install it in Unity. One last thing is to create an API Key for the 
openweather API so we can have real data about the location that we want to work and extract informations such as temperature, latitude, longitude, and other informations. To create an API key we have to create an account on the official site of openweather, go to account and 
create new API key and wait 1h or so for the activation of that token.

# Structuring the Project

After setting up all of those above we can now start working on the project itself. The first thing we gotta do is deleting the initial camera and create a new ```vufuria AR camera``` and a ```vufuria Multi-Target```. The AR camera being the main viewport and the Multi-Target
our object as when we detect with our camera so it can render the models in the "real world". Setting those two all left to do is to set up the license of the vufuria engine. To do that we must go to ```Resources > VufuriaConfiguration.asset``` in ```App License Key```.

All left to do now is import the models and link them in the multi-target object like this:

![image](https://github.com/user-attachments/assets/f8f07182-762f-46be-b3d0-32720b599718)

To set up the position of each model we can apply transformations in the Unity transform tab.

![image](https://github.com/user-attachments/assets/ce5dee0d-b959-4f5a-9b7c-2dfced84ecad)

and the result should look like this:

![image](https://github.com/user-attachments/assets/e4c9ceb2-34e4-4fd9-bcfa-66d4cfc8bcac)

# OpenWeather API

As you can see in the image above there is text, more precisely ```TextMeshPro``` which will allow us to display text in Unity on a 3D environnement. This will allow us to display the information that we want from the openweather API, such as temperature or other. And how can we do that? To do that we have to create a new ```C# Script``` and bind it with the ```TextMeshPro```. We drag the script into the TMP object so that the changes that we do on the script only apply to the TMP ONLY! And we link the ```TextMeshPro``` properties with the Script.

In Unity we can link properties that a object doesnt have access to by linking with a object of the same type as the property. Since we want to link the TMP with the script we create a object that allow us to have access to TMP and modify that specific TMP like this:

```C#
public TextMeshPro messageText;
```

![image](https://github.com/user-attachments/assets/3e10d625-cc11-48ef-944d-ede01ef6f957)

For the final step we only have to make the calls to the API with the information that want and set the text of the TMP with that text.

# Setting up Camera

For various reasons, i choose the ```iriun webcam```, link the ```Resources```, that will enable us to connect our mobile phone camera with our computer to do that have to download both softwares on the phone and on the pc. To link them you have be on the same network and that's it!

# Resources

<https://iriun.com/>






