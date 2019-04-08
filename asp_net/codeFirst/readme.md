# Install entity Fw
install-package EntityFramework -Version:6.1.3

# Migration from new db
enable-migrations // run in 1 times
add-migration InitialModel
update-database

# Migration from new db
enable-migrations // run in 1 times
add-migration InitialModel -IgnoreChanges -Force
update-database

