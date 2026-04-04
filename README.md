# DarwinWrap

DarwinWrap is a simple but powerful app for converting almost anything to a MSI installer.

## Licensing

DarwinWrap itself is licensed under the GNU AGPL 3.0 only. The exception to this rule are DarwinWrap's generators and runtime which are licensed under the GNU LGPL 3.0 only (and also any shared code which may be used by them).

There is an additional exception for the runtime which gets embedded into the MSI package. This is in place in order to allow the code to be embedded without "infecting" your application code. See LICENSE.EXCEPTION for details. Note this only covers code that gets embedded into the MSI if it gets embedded into the MSI! If this is not the case (i.e. you want to use the runtime code for something unreleated) the full LGPL applies.
