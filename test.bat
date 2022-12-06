cd ProjectSettings
for /F "tokens=2 delims=: " %%a in ('findstr /I "bundleVersion:" ProjectSettings.asset') do set test=%%a
echo value of test: %test%