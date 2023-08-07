// See https://aka.ms/new-console-template for more information
using PrototypePatternApp.Prototype;
using System;

Console.WriteLine("Hello, World!");

Profile profile = new Profile()
{
    Name = "KaulSudh",
    Email = "KaulSudh@Test.com"
};

profile.SetDateOfBirth(new DateTime(1973,5,26));
profile.SetSettings(new ProfileSettings()
{
    HideEmail = true,
    HideAge = false
});

DisplayProfile(profile);
Console.ReadKey();


//Edit Profile
Console.Write("\n\n\n");
Console.WriteLine("Edit Profile");
Console.WriteLine("---------------");

Profile editProfile = profile.Clone();
Console.WriteLine("Name: ");
editProfile.Name = Console.ReadLine();

Console.WriteLine("Email: ");
editProfile.Email = Console.ReadLine();

Console.Write("Private Profile (1  = yes): ");
editProfile.IsPrivate = Console.ReadLine() == "1";

Console.Write("Hide email (1  = yes): ");
editProfile.HideEmail = Console.ReadLine() == "1";

Console.Write("Hide Age (1  = yes): ");
editProfile.HideAge = Console.ReadLine() == "1";

Console.Write("\n\n\n");
DisplayProfile(editProfile);

Console.WriteLine();
Console.WriteLine("Would you like to save these changes? (1 = yes)");
bool saveChanges = Console.ReadLine() == "1";

Console.WriteLine();

if(saveChanges)
{
    profile = editProfile;
    Console.WriteLine("Successfully Saved profile");
}
else
{
    Console.WriteLine("Undoing profile changes...");
}

Console.Write("\n\n\n");
DisplayProfile(profile);
Console.ReadKey();

//Create Profile from prototype

ProfileSettings defaultSettingsPrototype = new ProfileSettings()
{
    IsPrivate = false,
    HideAge = true,
    HideEmail = true
};

ProfileSettings secureSettingsPrototype = new ProfileSettings()
{
    IsPrivate = true,
    HideAge = true,
    HideEmail = true
};

ProfileSettingsPrototypeRegistry settingsPrototypeRegistry = new ProfileSettingsPrototypeRegistry
(
    defaultSettingsPrototype,secureSettingsPrototype
);


Console.Write("\n\n\n");
Console.WriteLine("Create Profile");
Console.WriteLine("---------------");

Profile newProfile = new Profile();

Console.Write("Name: ");
newProfile.Name = Console.ReadLine();

Console.Write("Email: ");
newProfile.Email = Console.ReadLine();

Console.Write("Settings (1 = default, 2 = secure, other = custom)");
switch(Console.ReadLine())
{
    case "1": 
            newProfile.SetSettings(settingsPrototypeRegistry.CreateDefaultProfileSettings());
            break;
    case "2":
            newProfile.SetSettings(settingsPrototypeRegistry.CreateSecureProfileSettings());
            break;
    default:
            Console.Write("Private Profile (1  = yes): ");
            editProfile.IsPrivate = Console.ReadLine() == "1";

            Console.Write("Hide email (1  = yes): ");
            editProfile.HideEmail = Console.ReadLine() == "1";

            Console.Write("Hide Age (1  = yes): ");
            editProfile.HideAge = Console.ReadLine() == "1";    
            break;            
}

Console.WriteLine();
Console.WriteLine("Successfully created the profile");

DisplayProfile(newProfile);
Console.ReadKey();



 static void DisplayProfile(Profile profile)
        {
            Console.WriteLine("General");
            Console.WriteLine("------------");
            Console.WriteLine($"Name: {profile.Name}");

            if (!profile.HideEmail)
            {
                Console.WriteLine($"Email: {profile.Email}");
            }

            if (!profile.HideAge)
            {
                Console.WriteLine($"Age: {profile.Age}");
            }

            Console.WriteLine();

            Console.WriteLine("Settings");
            Console.WriteLine("------------");
            Console.WriteLine($"Private: {profile.IsPrivate}");
            Console.WriteLine($"Hide Email: {profile.HideEmail}");
            Console.WriteLine($"Hide Age: {profile.HideAge}");
        }




