<?php

namespace Database\Seeders;

use App\Models\orderStatus;
use Illuminate\Database\Seeder;

class OrderStatusSeeder extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
        $orderStatus = [
            ['id' => 1, 'status' => 'ontvangen'],
            ['id' => 2, 'status' => 'in bereiding'],
            ['id' => 3, 'status' => 'in de oven'],
            ['id' => 4, 'status' => 'klaar in de winkel'],
            ['id' => 5, 'status' => 'onderweg'],
            ['id' => 6, 'status' => 'bezorgd'],
        ];

        foreach ($orderStatus as $role) {
            orderStatus::create($role);
        }
    }
}
