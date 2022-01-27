<?php

namespace Database\Seeders;

use App\Models\orders;
use Illuminate\Database\Seeder;

class OrderSeeder extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
        $orders = [
            ['id' => 1, 'status_id' => '1', 'pizza_id' => '1'],
            ['id' => 2, 'status_id' => '2', 'pizza_id' => '2', 'user_id' => '6'],
        ];

        foreach ($orders as $role) {
            orders::create($role);
        }
    }
}
