<?php

namespace Database\Seeders;

use Illuminate\Database\Seeder;

class DatabaseSeeder extends Seeder
{
    /**
     * Seed the application's database.
     *
     * @return void
     */
    public function run()
    {
        $this->call([
            AdminUserSeeder::class,
            UserSeeder::class,
            RoleSeeder::class,
            UserRoleSeeder::class,
            OrderStatusSeeder::class,
            pizzaNameSeeder::class,
            ingredientSeeder::class,
            OrderSeeder::class,
            UnitSeeder::class,
            ItemsSeeder::class,
            pizzaSeeder::class,
        ]);
        // \App\Models\User::factory(10)->create();
    }
}
