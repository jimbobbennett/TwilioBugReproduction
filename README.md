# TwilioBugReproduction

Contains a reproduction for a bug in the Twilio Azure webjobs 3.0.0 stable release. Issue raised here - https://github.com/Azure/azure-webjobs-sdk-extensions/issues/502

This solution has 2 projects - TwilioBugReproduction.Working and TwilioBugReproduction.Failing. These prjects are identical except for the NuGet packages in use.

To use these, create an account at Twilio.com, add your twilio phone number to the `From` attribute in the `Run` method, and your mobile number to the `new PhoneNumber` line. Publish to Azure, and set the values for the published application settings for `TwilioAccountSid` and `TwilioAuthToken` to be the values from your account.

### TwilioBugReproduction.Working

This uses Microsoft.Azure.WebJobs.Extensions.Twilio 3.0.0-rc1. This one works.

### TwilioBugReproduction.Failing

This uses Microsoft.Azure.WebJobs.Extensions.Twilio 3.0.0. This one fails, the functions runtime is unable to start with this NuGet package in use.
